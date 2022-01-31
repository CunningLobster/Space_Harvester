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

        public void OnHyperjump(InputAction.CallbackContext context)
        {
            isJumping = context.ReadValueAsButton();
        }

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
