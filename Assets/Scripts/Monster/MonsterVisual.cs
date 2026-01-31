using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEngine.Audio.GeneratorInstance;

public class MonsterVisual : MonoBehaviour
{
    [Header("Meshes Lists")]
    [SerializeField] private List<MaskPair> maskPairs;
    [SerializeField] private List<PosMeshPair> posMeshPairs;
        
    private Dictionary<MaskType, GameObject> instantiatedMasks;
    private Dictionary<int, GameObject> meshReferences;

    private GameObject _currentMask;
    private GameObject _currentMesh;

    public void InitMeshReferences()
    {
        meshReferences = new Dictionary<int, GameObject>();

        foreach (var pair in posMeshPairs)
        {
            meshReferences[pair.pos] = pair.PosMesh;
            pair.PosMesh.SetActive(false);
        }
    }

    public void InstantiateMasks()
    {
        instantiatedMasks = new Dictionary<MaskType, GameObject>();

        foreach (var pair in maskPairs)
        {
            GameObject maskInstance = Instantiate(pair.maskMesh);
            maskInstance.SetActive(false);
            instantiatedMasks[pair.maskType] = maskInstance;
        }
    }

    public void ChangeMaskMesh(MaskType newMaskType)
    {
        if (instantiatedMasks.TryGetValue(newMaskType, out var newMask))
        {
            if (_currentMask != null)
                _currentMask.SetActive(false);

            if (_currentMesh != null)
            {
                Transform maskSocket = _currentMesh.transform.Find("MaskSocket");

                _currentMask = newMask;
                _currentMask.transform.SetParent(maskSocket);
                _currentMask.transform.localPosition = Vector3.zero;
                _currentMask.transform.localRotation = Quaternion.identity;
                _currentMask.SetActive(true);
            }
        }
    }

    public void ChangeMonsterMesh(int newMonsterPos)
    {
        if (meshReferences.TryGetValue(newMonsterPos, out var newMesh))
        {
            if (_currentMesh != null)
                _currentMesh.SetActive(false);

            _currentMesh = newMesh;
            _currentMesh.SetActive(true);

            if (_currentMask != null)
            {
                Transform maskSocket = _currentMesh.transform.Find("MaskSocket");
                _currentMask.transform.SetParent(maskSocket);
                _currentMask.transform.localPosition = Vector3.zero;
                _currentMask.transform.localRotation = Quaternion.identity;
            }
        }
    }

    public void RotateToPlayer()
    {
        transform.LookAt(MonsterMain.Instance.PlayerCam.transform.position);
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