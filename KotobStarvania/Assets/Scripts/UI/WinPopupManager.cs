using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
    public class WinPopupManager : MonoSingleton<WinPopupManager>
    {
        [Header("References")]
        [SerializeField] 
        private Animator animator;
        [SerializeField] private AudioSource winSound;

        [NonSerialized] public bool isShown = false;

        void Start()
        {
            animator = GetComponent<Animator>();

            HideWinPopup();
        }

        public void ShowWinPopup()
        {
            if (isShown){
                return;
            }
            isShown = true;
            winSound.Play();
            animator.SetTrigger("Show");
        }

        public void HideWinPopup()
        {
            animator.SetTrigger("Hide");
        }

        public void OnRestartPressed(){
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
     
    }
}