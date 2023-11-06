using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{

    public class KeyPickup : MonoBehaviour
    {

        [SerializeField] private DoorEnvironment door;
        void Start()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            {
                door.SetOpen();
                Destroy(gameObject);
            }
        }


    }
}