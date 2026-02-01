using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private static LoadScene instance = null;
    public static LoadScene Instance => instance;

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


    public void LoadLevelButton(string levelName)
    {
        LoadLevelAsync(levelName).Forget();
    }

    public void ReloadCurrentLevelButton()
    {
        ReloadCurrentLevelAsync().Forget();
    }

    public void QuitButton()
    {
        QuitAsync().Forget();
    }

    private async UniTask LoadLevelAsync(string levelName)
    {
        TransitionGame.Instance.CloseScene();
        await UniTask.WaitForSeconds(3f);
        SceneManager.LoadScene(levelName);
    }

    private async UniTask ReloadCurrentLevelAsync()
    {
        TransitionGame.Instance.CloseScene();
        await UniTask.WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private async UniTask QuitAsync()
    {
        TransitionGame.Instance.CloseScene();
        await UniTask.WaitForSeconds(3f);
        Application.Quit();
    }
}
