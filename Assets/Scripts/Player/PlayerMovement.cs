using UnityEngine;
using Unity.Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] public CinemachineCamera CamAvant { get; private set; }
    [SerializeField] private CinemachineCamera _camArriere;
    [SerializeField] private CinemachineCamera _camGauche;
    [SerializeField] private CinemachineCamera _camDroite;
    [field : SerializeField] public CinemachineCamera CamRadio { get; private set; }
    public int Position = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetCamera(CamAvant);
            Position = 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SetCamera(_camArriere);
            Position = 4;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SetCamera(_camGauche);
            Position = 3;
        }

        if (Input.GetKeyDown(KeyCode.D))
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
