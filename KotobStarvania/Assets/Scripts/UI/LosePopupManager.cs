using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Starvania
{
    public class LosePopupManager : MonoSingleton<LosePopupManager>
    {

        [Header("References")]
        [SerializeField] private GameObject losePopup;

        void Start()
        {
            HideLosePopup();
        }

        public void ShowLosePopup()
        {
            losePopup.SetActive(true);
        }

        public void HideLosePopup()
        {
            losePopup.SetActive(false);
        }

        public void OnRestartPressed(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

      
    }
}