using UnityEngine;

public class MonsterMain : MonoBehaviour
{
    private static MonsterMain instance = null;
    public static MonsterMain Instance => instance;

    public MonsterStateBrain MonsterBrain;
    public MonsterStateBrain MonsterTime;
    public MonsterMovement MonsterMovement;
    public MonsterVisual MonsterVisual;

    public int defaultPos = 3;
    public MaskState defaultMaskState;

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

        //Init ref for visual
        MonsterVisual.InitMeshReferences();
        MonsterVisual.InstantiateMasks();

        //StartPos
        MonsterMovement.MonsterMoveTo(defaultPos);
        //StartMask
        MonsterBrain.SwitchToThisMaskState(defaultMaskState);

    }
}
