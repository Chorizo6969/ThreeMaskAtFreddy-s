using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance => instance;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _winPanel;

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

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void Win()
    {
        _winPanel.SetActive(true);
    }
}
