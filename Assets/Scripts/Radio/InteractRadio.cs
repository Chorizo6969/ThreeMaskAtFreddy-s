using UnityEngine;

public class InteractRadio : MonoBehaviour
{
    [SerializeField] private Radio _radio;
    [SerializeField] private PlayerMovement _playerMovement;

    private bool wasHolding = false;

    void FixedUpdate()
    {
        OnRepair();
    }

    void OnRepair()
    {
        bool holding = Input.GetKey(KeyCode.V) && _playerMovement.Position == 1;

        if (holding)
        {
            wasHolding = true;
            _playerMovement.SetCamera(_playerMovement.CamRadio);
            _radio.Repair();
        }

        if (!holding && wasHolding)
        {
            wasHolding = false;

            _playerMovement.SetCamera(_playerMovement.CamAvant);
            _radio.Repair();
        }
    }
}
