using UnityEngine;
using UnityEngine.InputSystem;

public class InteractRadio : MonoBehaviour
{
    [SerializeField] private Radio _radio;
    [SerializeField] private PlayerMovement _playerMovement;

    private bool _repair = false;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started && _playerMovement.Position == 1)
        {
            _repair = true;
            _playerMovement.CanMove = false;
            _playerMovement.SetCamera(_playerMovement.CamRadio);
        }

        if (context.canceled)
        {
            _repair = false;
            _playerMovement.CanMove = true;
            _playerMovement.SetCamera(_playerMovement.CamAvant);
        }
    }

    void FixedUpdate()
    {
        RepairRadio();
    }

    void RepairRadio()
    {
        if (!_repair) return;

        _radio.Repair();
    }
}
