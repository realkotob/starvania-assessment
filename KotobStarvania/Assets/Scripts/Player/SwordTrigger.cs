using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania {
    public class SwordTrigger : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerMovement playerMovement;

        [Header("Settings")]

        [Tooltip("How long the sword collider is active")]
        [SerializeField]
        private float attackDuration = 0.2f;

        public UnityAction onSword;

        private CapsuleCollider2D swordCollider;
        void Start()
        {
            onSword += onSwordTrigger;

            swordCollider = GetComponent<CapsuleCollider2D>();

            DisableSwordCollider();
        }

        private void onSwordTrigger()
        {
            swordCollider.enabled = true;
            Invoke(nameof(DisableSwordCollider), attackDuration);
        }

        private void DisableSwordCollider()
        {
            swordCollider.enabled = false;
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out EnemyDeathState enemy))
            {
                enemy.StartDeathSequence(playerMovement.transform.position);
            }
            if (collider.gameObject.TryGetComponent(out EnemyProjectile projectile))
            {
                projectile.Deflect();
            }
        }
    }
}