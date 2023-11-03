using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float speed = 2f;

        [Header("References")]
        [SerializeField] private Animator animator;

        private Rigidbody2D rigidBody;
        void Start()
        {

            rigidBody = GetComponent<Rigidbody2D>();


            StartWalking();
        }

        private void StartWalking()
        {
            animator.SetTrigger("Walk");

            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rigidBody.velocity = randomDirection * speed;
        }

        void Update()
        {
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
