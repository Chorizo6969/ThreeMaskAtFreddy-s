using UnityEngine;

public class MonsterMain : MonoBehaviour
{
    private static MonsterMain instance = null;
    public static MonsterMain Instance => instance;

    public MonsterStateBrain MonsterBrain;
    public MonsterStateBrain MonsterTime;
    public MonsterMovement MonsterMovement;
    public MonsterVisual MonsterVisual;

    public GameObject Player;

    public int DefaultRow = 3;
    public MaskState DefaultMaskState;

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

        //StartRaw
        MonsterMovement.MonsterGoToThisRow(DefaultRow);
        //StartMask
        MonsterBrain.SwitchToThisMaskState(DefaultMaskState);

    }
}
