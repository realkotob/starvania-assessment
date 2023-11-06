using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
    public class KeyInfoManager : MonoSingleton<KeyInfoManager>
    {
        [Header("References")]
        [SerializeField] private TMPro.TextMeshProUGUI keyInfoText;
        [SerializeField] private int keyCount = 1;
        [SerializeField] private AudioSource keySound;

        private int keysCollected = 0;
        void Start()
        {
            UpdateKeyInfo();
        }

        public void SetKeyCollected()
        {
            keysCollected++;
            UpdateKeyInfo();
            keySound.Play();
        }

        public void UpdateKeyInfo()
        {
            keyInfoText.text = keysCollected + "/" + keyCount;
        }

        public bool IsAllKeysCollected()
        {
            return keysCollected >= keyCount;
        }
    }
}