using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class PlayerLookAt : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("Attack range in degrees")]
        [SerializeField] private float attackRange = 30f;
        [Tooltip("Attack duration in seconds")]
        [SerializeField] private float attackDuration = 0.2f;

        [Header("References")]
        [SerializeField] private GameObject swordParent;
        [SerializeField] private GameObject swordSprite;
        [SerializeField] private GameObject knightSprite;
        [SerializeField] private AudioSource attackSound;

        public UnityAction<Vector2> onLook;
        public UnityAction onSword;

        [NonSerialized] public Vector2 currentDirection;
        private bool isAttacking = false;
        void Start()
        {
            onLook += LookAround;
            onSword += SwordAttack;
        }

        void LookAround(Vector2 _direction)
        {

            if (Platform.IsOnPc())
            {
                _direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            }

            currentDirection = _direction;
            if (currentDirection.magnitude > 0 && !isAttacking)
            {
                swordParent.transform.rotation = Quaternion.LookRotation(Vector3.forward, currentDirection);
            }
        }

        void SwordAttack(){
            if(isAttacking){
                return;
            }
            isAttacking = true;
            attackSound.Play();
            swordParent.transform.DOKill();

            var centerRotation = Quaternion.LookRotation(Vector3.forward, currentDirection);
            swordParent.transform.rotation = centerRotation * Quaternion.Euler(0, 0, attackRange * Mathf.Sign(currentDirection.x));
            // Rotate to centerRotation +45 in 0.5 seconds
            swordParent.transform.DORotateQuaternion(centerRotation * Quaternion.Euler(0, 0, - attackRange * Mathf.Sign(currentDirection.x)), attackDuration).onComplete += () => {
                swordParent.transform.rotation = centerRotation;
                isAttacking = false;
            };

            swordSprite.transform.DOScale(0.8f, attackDuration / 2).SetEase(Ease.OutBack).onComplete += () => {
                swordSprite.transform.DOScale(0.65f, attackDuration / 2).SetEase(Ease.InBack);
            };


        }


    }
}