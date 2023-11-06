using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class PlayerMovement : MonoSingleton<PlayerMovement>
    {
        [Header("Settings")]
        [Tooltip("The speed at which the player moves")]
        [SerializeField] private float moveSpeed = 5;

        [Header("References")]
        [SerializeField] private Animator animator;

        public UnityAction<Vector2> onMove;

        private Rigidbody2D rigidBody;

        private Vector2 direction;

        private bool canMove = true;
        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();

            onMove += Move;
        }

        void Move(Vector2 _direction)
        {
            if(!canMove)
            {
                return;
            }
            direction = _direction;

            rigidBody.velocity = direction * moveSpeed;

            if(rigidBody.velocity.magnitude > 0)
            {
                animator.SetTrigger("Run");

                if (_direction.x > 0)
                {
                    animator.transform.localScale = new Vector3(1, 1, 1);
                    animator.transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction) * Quaternion.Euler(0, 0, 90);
                }
                else
                {
                    animator.transform.localScale = new Vector3(-1, 1, 1);
                    animator.transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction) * Quaternion.Euler(0, 0, -90);
                }

            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }

        internal void SetCanMove(bool value)
        {
            canMove = value;
            if(!canMove)
            {
                rigidBody.velocity = Vector2.zero;
            }
        }
    }
}