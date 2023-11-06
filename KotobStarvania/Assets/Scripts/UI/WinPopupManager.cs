using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
    public class WinPopupManager : MonoSingleton<WinPopupManager>
    {
        [Header("References")]
        [SerializeField] private GameObject winPopup;
        
         void Start()
        {
            HideWinPopup();
        }

        public void ShowWinPopup()
        {
            winPopup.SetActive(true);
        }

        public void HideWinPopup()
        {
            winPopup.SetActive(false);
        }

        public void OnRestartPressed(){
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
     
    }
}