using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class EnemyAttackState : MonoBehaviour
    {

        [Header("Settings")]

        private float projectileSpeed = 5;

        [Header("References")]
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject projectilePrefab;

        public UnityAction onAttack;
        void Start()
        {

        }

        public void StartAttack(Vector3 playerPosition)
        {
            onAttack?.Invoke();


            Vector3 direction = playerPosition - transform.position;
            direction.Normalize();

            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<EnemyProjectile>().Initialize(direction, projectileSpeed);

            projectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction) * Quaternion.Euler(0, 0, 0);
        }

        
    }
}