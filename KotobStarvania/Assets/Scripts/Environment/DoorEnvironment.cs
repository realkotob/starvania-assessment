using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Starvania
{

    public class DoorEnvironment : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject doorSpriteClosed;
        [SerializeField] private GameObject doorSpriteOpen;
        [SerializeField] private AudioSource doorOpenSound;
        void Start()
        {

        }

        public void SetOpen(){
            doorSpriteClosed.SetActive(false);
            doorSpriteOpen.SetActive(true);
            doorOpenSound.Play();
        }

        public void SetClosed(){
            doorSpriteClosed.SetActive(true);
            doorSpriteOpen.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            {
                if(KeyInfoManager.Instance.IsAllKeysCollected()){
                    playerMovement.SetCanMove(false);
                    WinPopupManager.Instance.ShowWinPopup();
                }
            }
        }

       
    }
}