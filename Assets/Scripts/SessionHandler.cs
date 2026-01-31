using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class SessionHandler : MonoBehaviour
{

    private static SessionHandler instance = null;
    public static SessionHandler Instance => instance;

    [SerializeField] Canvas _titleScreen;

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

    private void Start()
    {
        _titleScreen.gameObject.SetActive(true);
    }
    public void StartTheGame()
    {
        _titleScreen.gameObject.SetActive(false);
        GameStarted = true;

        MonsterMain.Instance.MonsterTimer.StartTimer();
    }

    public void PauseTheGame()
    {

    }
}
