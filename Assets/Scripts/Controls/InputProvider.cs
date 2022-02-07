using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceCarrier.Controls
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputProvider : MonoBehaviour
    {
        public Vector2 moveDirection { get; private set; }
        public bool isJumping { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }


        //Jump Performs on Space button or On Screen Hyperjump Button
        public void OnHyperjump(InputAction.CallbackContext context)
        {
            isJumping = context.ReadValueAsButton();
        }

        //For On Screen button
        public void OnBtnEnter()
        {
            isJumping = true;
        }
        public void OnBtnExit()
        {
            isJumping = false;
        }
    }
}
