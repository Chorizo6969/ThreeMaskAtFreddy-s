using System.Collections.Generic;
using UnityEngine;

public class MonsterVisual : MonoBehaviour
{
    public Dictionary<MaskType, GameObject> MaskDict = new Dictionary<MaskType, GameObject>();
    public Dictionary<int, GameObject> MeshDict = new Dictionary<int, GameObject>();

    [SerializeField] private GameObject _currentMaskEquiped;
    [SerializeField] private GameObject _currentMonsterPose;


    public void ChangeMaskMesh(MaskType _newMaskType)
    {
        _currentMaskEquiped = MaskDict[_newMaskType];
    }

    public void ChangeMonsterMesh(int _newMonsterPos)
    {
        _currentMonsterPose = MeshDict[_newMonsterPos];
    }
}
