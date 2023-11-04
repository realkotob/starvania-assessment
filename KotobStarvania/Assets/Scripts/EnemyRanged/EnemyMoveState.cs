using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class EnemyMoveState : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("The speed at which the enemy moves")]
        [SerializeField] private float moveSpeed = 2f;

        [Header("References")]
        [SerializeField] private Animator animator;
        [SerializeField] private EnemyDeathState enemyDeathAnimator;
        [SerializeField] private EnemyAttackState enemyRangedAttack;
        [SerializeField] private EnemyHookedState enemyHookedState;


        public UnityAction onWalk;
        
        private Rigidbody2D rigidBody;
        void Start()
        {

            rigidBody = GetComponent<Rigidbody2D>();


            StartWalking();
        }

        public void StartWalking()
        {
            if(enemyDeathAnimator.isDead)
            {
                return;
            }
            onWalk?.Invoke();

            animator.SetTrigger("Walk");

            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rigidBody.velocity = randomDirection * moveSpeed;
        }

        void Update()
        {
            CheckScreenBounds();
        }

        private void CheckScreenBounds()
        {
            if (enemyDeathAnimator.isDead || enemyHookedState.isHooked)
            {
                return;
            }
            // Reverse direction when reached edge of screen
            if (transform.position.x > 8.5f || transform.position.x < -8.5f)
            {
                rigidBody.velocity = new Vector2(-rigidBody.velocity.x, rigidBody.velocity.y);
            }

            if (transform.position.y > 4.5f || transform.position.y < -4.5f)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, -rigidBody.velocity.y);
            }
        }
    }
}
