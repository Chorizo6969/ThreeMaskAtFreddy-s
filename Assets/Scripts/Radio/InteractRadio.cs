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

            SoundManager.Instance.PlayRadioSound();
            _repair = true;
            _playerMovement.CanMove = false;
            _playerMovement.SetCamera(_playerMovement.CamRadio);
            _playerMovement.Position = 5;
        }

        if (context.canceled)
        {
            SoundManager.Instance.StopRadioSound();
            _repair = false;
            _playerMovement.CanMove = true;
            _playerMovement.SetCamera(_playerMovement.CamAvant);
            _playerMovement.Position = 1;
        }
    }

    void FixedUpdate()
    {
        RepairRadio();
    }

    void RepairRadio()
    {
        if (!_repair) return;
        if (Mathf.Floor(_radio.Current) % 10 == 0) _radio.PlayElectricityVFX();
        _radio.Repair();
    }
}
