using UnityEngine;
using UnityEngine.InputSystem;

public class InteractRadio : MonoBehaviour
{
    [SerializeField] private Radio _radio;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerMask _playerMask;
    [SerializeField] private MaskHandler _maskHandler;

    private bool _repair = false;

    public void OnInteract(InputAction.CallbackContext context)
    {

        if (!SessionHandler.Instance.GameStarted) return;

        if (context.started && _playerMovement.Position == 1)
        {
            if (_playerMask.currentMask != -1)
            {
                _playerMask.RemoveMask();
                //_maskHandler = _playerMask._maskHandlers[_playerMask.currentMask];
                //_maskHandler.OnDesequip();
            }

            _repair = true;
            _playerMovement.CanMove = false;
            _playerMovement.SetCamera(_playerMovement.CamRadio);
            _playerMovement.Position = 5;

            SoundManager.Instance.PlayRadioSound();
        }

        if (context.canceled)
        {
            _repair = false;
            _playerMovement.CanMove = true;
            _playerMovement.SetCamera(_playerMovement.CamAvant);
            _playerMovement.Position = 1;
            SoundManager.Instance.StopRadioSound();
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
