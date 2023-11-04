using System;
using System.Collections;
using System.Collections.Generic;
using Starvania;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class PlayerHookState : MonoBehaviour
    {

        [Header("Settings")]
        [SerializeField] private float hookSpeed = 2f;

        [Header("References")]
        [SerializeField] private PlayerLookAt playerLookAt;
        [SerializeField] private GameObject swordParent;

        public UnityAction onHook;

        [NonSerialized] public bool isHooking = false;

        private EnemyHookedState lastHookedEnemy;

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
        }
    }
}