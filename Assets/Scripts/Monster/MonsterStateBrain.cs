using UnityEngine;
using System.Collections.Generic;

public class MonsterStateBrain : MonoBehaviour
{
    [SerializeField] MaskState currentStateMask;
    [SerializeField] List<MaskState> MaskStateList;

    public void SwitchMask()
    {
        currentStateMask.OnExit();
        currentStateMask = GetRandomMask();
        currentStateMask.OnEnter();
    }

    private MaskState GetRandomMask()
    {
        int randomIndex = Random.Range(0, MaskStateList.Count);
        return MaskStateList[randomIndex];
    }
}
