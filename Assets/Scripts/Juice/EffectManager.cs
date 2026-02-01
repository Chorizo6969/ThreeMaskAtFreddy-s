using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class EffectManager : MonoBehaviour
{
    public LightHandler LightHandler { get; private set; }

    // Singleton
    #region Singleton
    private static EffectManager _instance;

    public static EffectManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("EffectManager is null");
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            Debug.Log("EffectManager instance <color=#eb624d>destroyed</color>");
        }
        else
        {
            _instance = this;
            Debug.Log("EffectManager instance <color=#58ed7d>created</color>");
        }

        LightHandler = GetComponent<LightHandler>();
    }
    #endregion

    private void Start()
    {
        PostProcessHandler.Instance.StartVignetteLoop();
    }

    public async void MaskVignetteFocus(Color maskColor)
    {
        PostProcessHandler.Instance.StopAllCoroutines();
        PostProcessHandler.Instance.ChangeVignette(0.45f, 0.3f);
        await PostProcessHandler.Instance.DoVignetteColor(maskColor, 0.3f);
    }

    public async void ResetVignette()
    {
        await PostProcessHandler.Instance.ResetVignette(0.2f);
    }

    public void BlinkAllLane(float blinkTime)
    {
        LightHandler._backLaneLight.CallBlinkOnce(blinkTime);
        LightHandler._rightLaneLight.CallBlinkOnce(blinkTime);
        LightHandler._leftLaneLight.CallBlinkOnce(blinkTime);
    }

    public void BlinkAllLight(float blinkTime)
    {
        Debug.Log("AllLight");
        LightHandler._backLaneLight.CallBlinkOnce(blinkTime);
        LightHandler._rightLaneLight.CallBlinkOnce(blinkTime);
        LightHandler._leftLaneLight.CallBlinkOnce(blinkTime);
        LightHandler._deskLight.CallBlinkOnce(blinkTime);
        LightHandler.StartCoroutine(LightHandler.BlinkPointLight(blinkTime));
    }


}
