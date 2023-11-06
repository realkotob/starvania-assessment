using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Starvania
{
    public class LosePopupManager : MonoSingleton<LosePopupManager>
    {

        [Header("References")]
        [SerializeField] 
        private Animator animator;
        [SerializeField] private AudioSource loseSound;

        private bool isShown = false;

        void Start()
        {
            animator = GetComponent<Animator>();

            HideLosePopup();
        }

        public void ShowLosePopup()
        {
            if (isShown){ 
                return;
            }
            isShown = true;
            loseSound.Play();
            animator.SetTrigger("Show");
        }

        public void HideLosePopup()
        {
            animator.SetTrigger("Hide");
        }

        public void OnRestartPressed(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

      
    }
}