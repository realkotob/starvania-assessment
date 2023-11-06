using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Starvania
{
    public class ManaSliderManager : MonoSingleton<ManaSliderManager>
    {
        [Header("References")]
        [SerializeField] private Slider manaSlider;
        
        void Start()
        {

        }

        public void SetMana(float health)
        {
            manaSlider.value = health;
        }

        
    }
}