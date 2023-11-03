using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class EnemyAttackState : MonoBehaviour
    {

        public UnityAction onAttack;
        void Start()
        {

        }

        void StartAttack()
        {
            onAttack?.Invoke();
        }

        
    }
}