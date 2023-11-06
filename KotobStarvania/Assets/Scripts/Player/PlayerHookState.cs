using System;
using System.Collections;
using System.Collections.Generic;
using Starvania;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class PlayerHookState : MonoBehaviour
    {

        [Header("Settings")]
        [Tooltip("The speed of the hook")]
        [SerializeField] private float hookSpeed = 2f;
        [Tooltip("The speed at which the hook mana regenerates")]
        [SerializeField] private float hookManaRegen = 0.1f;
        [Tooltip("The speed at which the hook mana drains")]
        [SerializeField] private float hookManaDrain = 0.2f;

        [Header("References")]
        [SerializeField] private PlayerLookAt playerLookAt;
        [SerializeField] private GameObject swordParent;
        [SerializeField] private HookLinkPool hookLinkPool;
        [SerializeField] private AudioSource hookSound;

        public UnityAction onHook;

        [NonSerialized] public bool isHooking = false;

        private EnemyHookedState lastHookedEnemy;

        private float hookMana = 1f;
   

        // Start is called before the first frame update
        void Start()
        {
            onHook += Hook;
        }

        private void Hook()
        {
            if(isHooking){
                return;
            }

            var currentDirection = playerLookAt.currentDirection;

            // Raycast to find the closest hookable object
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, currentDirection, 10f, LayerMask.GetMask("Enemy"));
            RaycastHit2D closestHit = new RaycastHit2D();
            float closestDistance = 1000f;
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent(out EnemyDeathState hookable))
                {
                    float distance = Vector2.Distance(transform.position, hit.point);
                    if (distance < closestDistance && !hookable.isDead)
                    {
                        closestDistance = distance;
                        closestHit = hit;
                    }
                }
            }

            if (closestHit.collider != null)
            {
                hookSound.Play();

                isHooking = true;
                swordParent.SetActive(false);

                lastHookedEnemy = closestHit.collider.gameObject.GetComponent<EnemyHookedState>();
                var hookDuration = lastHookedEnemy.Hook(transform.position, hookSpeed);
                
                Invoke(nameof(ResetHook), hookDuration);
            }

        }

        public void ResetHook()
        {
            isHooking = false;
            swordParent.SetActive(true);

            lastHookedEnemy.ResetHook();
            hookLinkPool.HideHookLinks();
        }

        public void Update(){
            if(isHooking){
                UpdateHookLinks();
            }
            else if (hookMana < 1f)
            {
                hookMana += hookManaRegen * Time.deltaTime;
                hookMana = Mathf.Min(1f, hookMana);
                ManaSliderManager.Instance.SetMana(hookMana);
            }
        }

        private void UpdateHookLinks()
        {
            hookMana -= hookManaDrain * Time.deltaTime;
            ManaSliderManager.Instance.SetMana(hookMana);
            if(hookMana <= 0){
                ResetHook();
                return;
            }

            hookLinkPool.HideHookLinks();

            var hookDirection = (lastHookedEnemy.transform.position - transform.position).normalized;

            var distance = Vector2.Distance(transform.position, lastHookedEnemy.transform.position);
            var hookLinkCount = Mathf.FloorToInt(distance / 0.15f);

            for (int i = 0; i < hookLinkCount; i++)
            {
                var hookLinkPosition = transform.position + (hookDirection * (i + 1) * 0.15f);
                var hookLink = hookLinkPool.GetHookLink();
                hookLink.transform.position = hookLinkPosition;
                hookLink.SetActive(true);
            }
        }
    }
}