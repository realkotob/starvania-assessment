using System.Collections;
using System.Collections.Generic;
using Starvania;
using UnityEngine;
using UnityEngine.UI;

namespace Starvania
{
    public class HealthSliderManager : MonoSingleton<HealthSliderManager>
    {
        [Header("References")]
        [SerializeField] private Slider healthSlider;
        [SerializeField] private AudioSource potionHealSound;
        [SerializeField] private AudioSource damageSound;

        [Header("Settings")]
        [SerializeField] private float maxHealth = 100;
        private float currentHealth = 100;

        void Start()
        {
            SetHealth(maxHealth);
        }

        public void SetHealth(float health)
        {
            currentHealth = health;
            healthSlider.value = currentHealth / maxHealth;
        }

        public void AddHealth(float health)
        {
            currentHealth = Mathf.Min(maxHealth, health + currentHealth);
            healthSlider.value = currentHealth / maxHealth;
            potionHealSound.Play();
        }

        public void RemoveHealth(float health)
        {
            currentHealth -= health;
            healthSlider.value = currentHealth / maxHealth;
            damageSound.Play();
            if (currentHealth <= 0)
            {
                PlayerMovement.Instance.SetCanMove(false);
                LosePopupManager.Instance.ShowLosePopup();
            }
        }
    }
}