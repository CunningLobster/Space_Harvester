using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace SpaceCarrier.Controls
{
    public class InputProvider : MonoBehaviour
    {
        public Vector2 moveDirection { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }

        private void Update()
        {
            print(moveDirection);
        }
    }
}
