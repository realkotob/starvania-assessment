using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Starvania
{
    public class EnemyProjectile : MonoBehaviour
    {

        private Rigidbody2D rigidBody;
        private Vector3 startDirection;


        private bool isDeflected = false;

        void Start()
        {
            Destroy(gameObject, 10f);
        }

        public void Initialize(Vector3 direction, float projectileSpeed)
        {
            rigidBody = GetComponent<Rigidbody2D>();

            startDirection = direction;

            rigidBody.velocity = direction * projectileSpeed;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!isDeflected && other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            {
                // TODO: Add damage to player
                Destroy(gameObject);
            }

            if (isDeflected && other.gameObject.TryGetComponent(out EnemyDeathState enemy))
            {
                enemy.StartDeathSequence(transform.position);
                Destroy(gameObject);
            }
        }

        internal void Deflect()
        {

            if(isDeflected)
            {
                return;
            }

            isDeflected = true;

            rigidBody.velocity =  -startDirection * rigidBody.velocity.magnitude;

            transform.Rotate(0, 0, 180);

        }
    }
}