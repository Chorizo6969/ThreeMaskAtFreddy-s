using UnityEngine;
using System.Collections.Generic;

public class MonsterStateBrain : MonoBehaviour
{
    [SerializeField] MaskState currentStateMask;
    [SerializeField] List<MaskState> MaskStateList;

    public MaskType CurrentMask;
    public void SwitchToThisMaskState(MaskState _newMask)
    {
        currentStateMask = _newMask;
    }

    public void SwitchToNewMaskState(MaskState _newMask)
    {
        currentStateMask.OnExit();
        currentStateMask = _newMask;
        currentStateMask.OnEnter();
    }

    public MaskState GetRandomMaskState()
    {
        int randomIndex = Random.Range(0, MaskStateList.Count);
        return MaskStateList[randomIndex];
    }
}
