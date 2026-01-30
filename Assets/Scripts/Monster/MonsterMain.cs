using UnityEngine;

public class MonsterMain : MonoBehaviour
{
    private static MonsterMain instance = null;
    public static MonsterMain Instance => instance;

    public MonsterStateBrain MonsterBrain;
    public MonsterStateBrain MonsterTime;
    public MonsterMovement MonsterMovement;
    public MonsterVisual MonsterVisual;

    public MaskType CurrentMask;

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
}
