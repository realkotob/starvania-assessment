using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Starvania
{

    public class DoorEnvironment : MonoBehaviour
    {
        [SerializeField] private GameObject doorSpriteClosed;
        [SerializeField] private GameObject doorSpriteOpen;
        void Start()
        {

        }

        public void SetOpen(){
            doorSpriteClosed.SetActive(false);
            doorSpriteOpen.SetActive(true);
        }

        public void SetClosed(){
            doorSpriteClosed.SetActive(true);
            doorSpriteOpen.SetActive(false);
        }

       
    }
}