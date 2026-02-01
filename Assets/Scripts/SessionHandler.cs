using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

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
        DontDestroyOnLoad(this.gameObject);
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
    }
}
