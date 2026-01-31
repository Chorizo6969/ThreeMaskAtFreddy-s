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

}
