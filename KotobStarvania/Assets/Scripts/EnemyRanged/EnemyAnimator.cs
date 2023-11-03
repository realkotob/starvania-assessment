using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Starvania
{
    public class EnemyAnimator : MonoBehaviour
    {
        [Header("Settings")]

        [SerializeField] private float knockBackStrength = 1f;
        [SerializeField] private float knockBackDuration = 0.2f;

        [Header("References")]

        [SerializeField] private Animator animator;
        void Start()
        {

        }

        public void playHurtAnimation()
        {
            animator.SetTrigger("Hurt");
        }

        internal void knockBack(Vector3 position)
        {
            transform.DOKill();
            var direction = (transform.position - position).normalized;
            transform.DOMove(transform.position + (direction * knockBackStrength), knockBackDuration);
        }
    }
}