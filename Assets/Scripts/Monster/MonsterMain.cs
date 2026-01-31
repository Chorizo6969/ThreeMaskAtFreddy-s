using UnityEngine;

public class MonsterMain : MonoBehaviour
{
    private static MonsterMain instance = null;
    public static MonsterMain Instance => instance;

    public MonsterStateBrain MonsterBrain;
    public MonsterTimer MonsterTimer;
    public MonsterMovement MonsterMovement;
    public MonsterVisual MonsterVisual;
    public MonsterEncounter MonsterEncounter;

    [Header("DefaultValues")] 
    public GameObject PlayerCam;
    public int DefaultRow = 3;
    public MaskState DefaultMaskState;
    public float DefaultDelayBetweenActions = 8f;

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
        MonsterMovement.InitPosReferences();

        //StartRaw
        MonsterMovement.MonsterGoToThisRow(DefaultRow);
        //StartMask
        MonsterBrain.SwitchToThisMaskState(DefaultMaskState);

    }
}
