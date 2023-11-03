using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Starvania
{
    public class EnemyAttackTrigger : MonoBehaviour
    {

        [Header("References")]
        [SerializeField] private EnemyAttackState enemyRangedAttack;

        void Start()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            {
                enemyRangedAttack.StartAttack(playerMovement.transform.position);
            }
        }



       
    }
}