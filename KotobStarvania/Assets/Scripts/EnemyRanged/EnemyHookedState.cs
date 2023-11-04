using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Starvania
{

    public class EnemyHookedState : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private EnemyMoveState enemyMovement;
        
        [NonSerialized] public bool isHooked = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        internal float Hook(Vector3 playerPosition, float hookSpeed)
        {
            isHooked = true;

            var targetPosition = playerPosition - (playerPosition - transform.position).normalized;
            var distance = Vector2.Distance(transform.position, targetPosition);
            var hookDuration = distance / hookSpeed;

            transform.DOMove(targetPosition, hookDuration);
            
            return hookDuration;
        }

        public void ResetHook()
        {
            isHooked = false;

            enemyMovement.StartWalking();
        }
    }
}