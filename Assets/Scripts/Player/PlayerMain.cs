using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private static PlayerMain instance = null;
    public static PlayerMain Instance => instance;

    public PlayerMovement PlayerMovement;
    public PlayerMask PlayerMask;
    public PlayerLook PlayerLook;
    public CameraVisionRay CameraVisionRay;
    public PlayerAnim PlayerAnim;
    public PlayerInputHandler PlayerInput;

    public Camera PlayerCam;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
}
