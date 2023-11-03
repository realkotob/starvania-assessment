using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class PlayerMovement : MonoBehaviour
    {

        [Header("References")]
        [SerializeField] private Animator animator;

        public UnityAction<Vector2> onMove;

        private Rigidbody2D rigidBody;

        private Vector2 direction;
        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();

            onMove += Move;
        }

        void Move(Vector2 _direction)
        {
            direction = _direction;

            rigidBody.velocity = direction * 5;

            if(rigidBody.velocity.magnitude > 0)
            {
                animator.SetTrigger("Run");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }

  
    }
}