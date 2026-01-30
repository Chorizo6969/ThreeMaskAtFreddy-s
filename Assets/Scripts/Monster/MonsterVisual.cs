using System.Collections.Generic;
using UnityEngine;

public class MonsterVisual : MonoBehaviour
{
    [Header("Current Meshes")]
    [SerializeField] private GameObject _currentMaskEquipped;
    [SerializeField] private GameObject _currentMonsterPose;

    [Header("Meshes Lists")]
    [SerializeField] private List<MaskPair> maskPairs;
    [SerializeField] private List<PosMeshPair> posMeshPairs;

    private Dictionary<MaskType, GameObject> MaskDict;
    private Dictionary<int, GameObject> MeshDict;

    private void Awake()
    {
        InitDictionaries();
    }

    void InitDictionaries()
    {
        MaskDict = new Dictionary<MaskType, GameObject>();
        foreach (var pair in maskPairs)
            MaskDict[pair.maskType] = pair.maskMesh;

        MeshDict = new Dictionary<int, GameObject>();
        foreach (var pair in posMeshPairs)
            MeshDict[pair.pos] = pair.PosMesh;
    }

    public void ChangeMaskMesh(MaskType newMaskType)
    {
        if (MaskDict.TryGetValue(newMaskType, out var mesh))
            _currentMaskEquipped = mesh;
    }

    public void ChangeMonsterMesh(int newMonsterPos)
    {
        if (MeshDict.TryGetValue(newMonsterPos, out var mesh))
            _currentMonsterPose = mesh;
    }

    [System.Serializable]
    public class MaskPair
    {
        public MaskType maskType;
        public GameObject maskMesh;
    }

    [System.Serializable]
    public class PosMeshPair
    {
        public int pos;
        public GameObject PosMesh;
    }
}
