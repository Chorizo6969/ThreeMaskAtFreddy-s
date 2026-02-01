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

    public void BlinkAllLight(float blinkTime)
    {
        if(LightHandler._backLaneLight != null) LightHandler._backLaneLight.CallBlinkOnce(blinkTime);
        if (LightHandler._deskLight != null) LightHandler._deskLight.CallBlinkOnce(blinkTime);
        if (LightHandler._rightLaneLight != null) LightHandler._rightLaneLight.CallBlinkOnce(blinkTime);
        if (LightHandler._leftLaneLight != null) LightHandler._leftLaneLight.CallBlinkOnce(blinkTime);

    }
}
