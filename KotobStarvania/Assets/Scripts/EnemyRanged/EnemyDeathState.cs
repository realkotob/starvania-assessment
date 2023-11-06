using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class EnemyDeathState : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("How far the enemy will be knocked back when killed")]
        [SerializeField] private float knockBackStrength = 1f;
        [Tooltip("How long the enemy will be knocked back when killed")]
        [SerializeField] private float knockBackDuration = 0.2f;

        [Header("References")]

        [SerializeField] private Animator animator;
        [SerializeField] private GameObject healthPickupPrefab;
        [SerializeField] private AudioSource gruntSound;
        [SerializeField] private AudioSource dieSound;

        public UnityAction onDeath;
        [NonSerialized] public bool isDead = false;

        void Start()
        {

        }

        public void StartDeathSequence(Vector3 position)
        {
            if(isDead){
                return;
            }

            gruntSound.Play();

            onDeath?.Invoke();

            isDead = true;

            PlayHurtAnimation();
            KnockBack(position);

            Invoke(nameof(PlayDeathAnimation), knockBackDuration);
        }

        public void PlayHurtAnimation()
        {
            animator.SetTrigger("Hurt");
        }

        internal void KnockBack(Vector3 position)
        {
            transform.DOKill();
            var direction = (transform.position - position).normalized;
            transform.DOMove(transform.position + (direction * knockBackStrength), knockBackDuration);
        }

        public void PlayDeathAnimation()
        {
            dieSound.Play();
            animator.SetTrigger("Die");

            if (UnityEngine.Random.Range(0, 100) < 15)
            {
                Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);
            }
        }

        internal void FinishDeathAnimation()
        {
            Destroy(gameObject);
        }
    }
}