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

        void Start()
        {

        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Debug.Log("Value: " + context.ReadValue<Vector2>());
        } 

        public void OnLook(InputAction.CallbackContext context)
        {
            // Debug.Log(context);
        } 

        public void OnSword(InputAction.CallbackContext context)
        {
            Debug.Log(context);
        }

        public void OnHook(InputAction.CallbackContext context)
        {
            Debug.Log(context);
        } 
    }
}