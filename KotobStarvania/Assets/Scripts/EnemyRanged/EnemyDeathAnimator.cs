using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Starvania
{
    public class EnemyDeathAnimator : MonoBehaviour
    {
        [Header("Settings")]

        [SerializeField] private float knockBackStrength = 1f;
        [SerializeField] private float knockBackDuration = 0.2f;

        [Header("References")]

        [SerializeField] private Animator animator;

        private bool isDead = false;

        void Start()
        {

        }

        public void StartDeathSequence(Vector3 position)
        {
            if(isDead){
                return;
            }

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
            animator.SetTrigger("Die");
        }

        internal void FinishDeathAnimation()
        {
            Destroy(gameObject);
        }
    }
}