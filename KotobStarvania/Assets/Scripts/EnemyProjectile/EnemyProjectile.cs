using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Starvania
{
    public class EnemyProjectile : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject, 10f);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            {
                Destroy(gameObject);
            }
        }
    }
}