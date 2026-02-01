using UnityEngine;

public class SessionHandler : MonoBehaviour
{

    private static SessionHandler instance = null;
    public static SessionHandler Instance => instance;

    public bool GameStarted = false;

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

    private void Start()
    {
        StartTheGame();
    }

    public void StartTheGame()
    {
        UIManager.Instance.RemoveTitleScreen();
        GameStarted = true;

        MonsterMain.Instance.MonsterTimer.StartTimer();
    }

    public void PauseTheGame()
    {

    }

    public void StopTheGame()
    {
        GameStarted = false;
        MonsterMain.Instance.MonsterTimer.StopTimer();
    }
}
