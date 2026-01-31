using UnityEngine;
using System.Collections.Generic;

public class MonsterStateBrain : MonoBehaviour
{
    [SerializeField] MaskState currentStateMask;
    [SerializeField] List<MaskState> MaskStateList;

    public MaskType CurrentMask;
    public void SwitchToThisMaskState(MaskState newMask)
    {
        currentStateMask = newMask;
        currentStateMask.OnEnter();
    }

    public void SwitchToNewMaskState(MaskState newMask)
    {
        currentStateMask.OnExit();
        currentStateMask = newMask;
        currentStateMask.OnEnter();
    }

    public MaskState GetRandomMaskState()
    {
        int randomIndex = Random.Range(0, MaskStateList.Count);
        return MaskStateList[randomIndex];
    }
}
