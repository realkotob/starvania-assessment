using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
    public class EnemySpriteAnimator : MonoBehaviour
    {

        [Header("References")]
        [SerializeField] private EnemyDeathAnimator deathAnimator;
        void Start()
        {

        }

        public void onDeathAnimationFinish()
        {
            deathAnimator.FinishDeathAnimation();
        }

    }
}
