using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance => instance;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _titlePanel;

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

    public void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void ShowWinPanel()
    {
        _winPanel.SetActive(true);
    }

    public void RemoveTitleScreen()
    {
        _titlePanel.SetActive(false);
    }
}
