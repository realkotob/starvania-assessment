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

        void Start()
        {

        }

        public void OnMove(InputAction.CallbackContext context)
        {
            playerMovement.onMove?.Invoke(context.ReadValue<Vector2>());
        } 

        public void OnLook(InputAction.CallbackContext context)
        {
            playerLookAt.onLook?.Invoke(context.ReadValue<Vector2>());
        } 

        public void OnSword(InputAction.CallbackContext context)
        {
            playerLookAt.onSword?.Invoke();
        }

        public void OnHook(InputAction.CallbackContext context)
        {
            Debug.Log(context);
        } 
    }
}