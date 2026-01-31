using Unity.VisualScripting;
using UnityEngine;

public class SessionHandler : MonoBehaviour
{
    [SerializeField] Canvas _titleScreen;

    private void Start()
    {
        _titleScreen.gameObject.SetActive(true);
        PlayerMain.Instance.PlayerMovement.CanMove = false;
    }
    public void StartTheGame()
    {
        _titleScreen.gameObject.SetActive(false);
    }

    public void PauseTheGame()
    {

    }
}
