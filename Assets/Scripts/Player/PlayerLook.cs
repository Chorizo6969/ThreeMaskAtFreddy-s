using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script qui gère la camera du joueur quand il tourne (relié au playerInput)
/// </summary>
public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float rotateSpeed = 8f;

    private Vector2 lookInput;
    private float targetYaw = 0f;

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        UpdateTargetRotation();
    }

    private void Update()
    {
        float currentY = _camera.localEulerAngles.y;
        float smoothY = Mathf.LerpAngle(currentY, targetYaw, rotateSpeed * Time.deltaTime);
        _camera.localRotation = Quaternion.Euler(13.5f, smoothY, 0f); //Légère inclinaison en x pour bien voir la table mais pas obligeatoire
    }

    private void UpdateTargetRotation()//Selon si j'appuie sur ZQSD dans mon input système j'ai une value différente et c'est ici que je dis ok la rota sera de 90 degré
    {
        if (lookInput == Vector2.zero)
        {
            targetYaw = 0f;
            return;
        }

        if (lookInput.x < 0)
            targetYaw = -90f;
        else if (lookInput.x > 0)
            targetYaw = 90f;
        else if (lookInput.y < 0)
            targetYaw = 180f;
        else
            targetYaw = 0f;
    }
}