using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerMask playerMask;
    [SerializeField] private PlayerMovement _playerMovement;

    public void OnEquipMask(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (_playerMovement.Position != 1) return;

        int maskIndex = GetMaskIndexFromInput(context);
        if (maskIndex == -1) return;
        if (playerMask.currentMask == maskIndex) playerMask.RemoveMask();
        else playerMask.EquipMask(maskIndex);
    }

    private int GetMaskIndexFromInput(InputAction.CallbackContext context)
    {
        InputControl control = context.control;

        if (control == Keyboard.current.digit1Key) return 0;
        if (control == Keyboard.current.digit2Key) return 1;
        if (control == Keyboard.current.digit3Key) return 2;

        return -1;
    }
}