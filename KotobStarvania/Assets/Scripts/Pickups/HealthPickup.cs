using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
    public class HealthPickup : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            {
                HealthSliderManager.Instance.AddHealth(20);
                Destroy(gameObject);
            }
        }
    }
}