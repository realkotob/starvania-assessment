using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
    public class KeyInfoManager : MonoSingleton<KeyInfoManager>
    {
        [SerializeField] private TMPro.TextMeshProUGUI keyInfoText;
        [SerializeField] private int keyCount = 1;
        private int keysCollected = 0;
        void Start()
        {
            UpdateKeyInfo();
        }

        public void SetKeyCollected()
        {
            keysCollected++;
            UpdateKeyInfo();
        }

        public void UpdateKeyInfo()
        {
            keyInfoText.text = keysCollected + "/" + keyCount;
        }
       
    }
}