using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Starvania
{
    public class PlayerInput : MonoBehaviour
    {
        
        [Header("References")]
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerLookAt playerLookAt;
        [SerializeField] private SwordTrigger swordTrigger;
        [SerializeField] private PlayerHookState playerHookState;

        void Start()
        {

        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (playerHookState.isHooking)
            {
                // Cancel hooking
                playerHookState.ResetHook();
                return;
            }
            playerMovement.onMove?.Invoke(context.ReadValue<Vector2>());
        } 

        public void OnLook(InputAction.CallbackContext context)
        {
            playerLookAt.onLook?.Invoke(context.ReadValue<Vector2>());
        } 

        public void OnSword(InputAction.CallbackContext context)
        {
            if(playerHookState.isHooking){
                // Attacking while hooking stops hooking
                playerHookState.ResetHook();
            }

            playerLookAt.onSword?.Invoke();
            swordTrigger.onSword?.Invoke();
        }

        public void OnHook(InputAction.CallbackContext context)
        {
            if (playerHookState.isHooking)
            {
                // Cancel hooking
                playerHookState.ResetHook();
                return;
            }

            playerHookState.onHook?.Invoke();
        } 
    }
}