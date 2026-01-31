using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessHandler : MonoBehaviour
{
    public Volume Volume { get; private set; }

    // Specific settings
    private float _baseVignetteIntensity;

    // Singleton
    #region Singleton
    private static PostProcessHandler _instance;

    public static PostProcessHandler Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("PostProcessHandler is null");
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            Debug.Log("PostProcessHandler instance <color=#eb624d>destroyed</color>");
        }
        else
        {
            _instance = this;
            Debug.Log("PostProcessHandler instance <color=#58ed7d>created</color>");
        }

        Volume = Camera.main.GetComponentInChildren<Volume>();
    }
    #endregion

    private void Start()
    {
        Volume.profile.TryGet(out Vignette vignette);
        _baseVignetteIntensity = (float)vignette.intensity;
    }

    [ContextMenu("Truc")]
    public void Truc()
    {
        Loop();
    }

    #region Vignette
    public async UniTask ChangeVignette(float newIntensity, float duration)
    {
        Volume.profile.TryGet(out Vignette vignette);
        float currentIntensity = (float)vignette.intensity;

        int steps = Mathf.CeilToInt(Mathf.Abs((newIntensity - currentIntensity) / 0.01f));
        int delay = (int)(duration * 1000f / steps);

        // TODO: remplacer la double boucle par un lerp simple

        // ascending
        if (newIntensity > currentIntensity)
        {
            for (float f = currentIntensity; f < newIntensity; f += 0.01f)
            {
                vignette.intensity.Override(f);
                await UniTask.Delay(delay);
            }
        }
        //descending
        else
        {
            for (float f = currentIntensity; f > newIntensity; f -= 0.01f)
            {
                vignette.intensity.Override(f);
                await UniTask.Delay(delay);
            }
        }
    }

    private async void Loop()
    {
        while (true)
        {
            await ChangeVignette(0.25f, 0.5f);
            await ChangeVignette(0.2f, 0.5f);
        }
    }

    public async UniTask ResetVignette(float duration)
    {
        await ChangeVignette(_baseVignetteIntensity, duration);
    }
    #endregion
}
