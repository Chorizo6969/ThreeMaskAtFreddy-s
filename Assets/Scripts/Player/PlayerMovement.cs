using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] public CinemachineCamera CamAvant { get; private set; }
    [SerializeField] private CinemachineCamera _camArriere;
    [SerializeField] private CinemachineCamera _camGauche;
    [SerializeField] private CinemachineCamera _camDroite;
    [field: SerializeField] public CinemachineCamera CamRadio { get; private set; }
    public int Position = 1;
    public bool CanMove = true;
    private Vector2 moveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!SessionHandler.Instance.GameStarted) return;
        if (context.started && CanMove)
        {
            moveInput = context.ReadValue<Vector2>();
            UpdateCamera();
            CanMove = false;
        }

        if (context.canceled)
        {
            moveInput = context.ReadValue<Vector2>();
            UpdateCamera();
            CanMove = true;
        }
    }

    public void UpdateCamera()
    {
        if (moveInput == Vector2.zero)
        {
            SetCamera(CamAvant);
            Position = 1;
        }
        else if (moveInput.y < 0)
        {
            SetCamera(_camArriere);
            Position = 4;
        }
        else if (moveInput.x < 0)
        {
            SetCamera(_camGauche);
            Position = 3;
        }
        else if (moveInput.x > 0)
        {
            SetCamera(_camDroite);
            Position = 2;
        }
    }

    public void SetCamera(CinemachineCamera cam)
    {
        CamAvant.Priority = 0;
        _camArriere.Priority = 0;
        _camGauche.Priority = 0;
        _camDroite.Priority = 0;
        CamRadio.Priority = 0;

        cam.Priority = 10;
    }
}
