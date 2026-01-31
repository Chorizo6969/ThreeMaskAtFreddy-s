using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 0 = Right
// 1 = Left
// 2 = Back
public class MonsterMovement : MonoBehaviour
{
    [System.Serializable]
    public class RowPair
    {
        public int RowNumber;
        public List<GameObject> PositionsList;
    }

    public int CurrentRow;

    [Header("Pos Lists")]
    [SerializeField] private List<RowPair> rowPair;
    [SerializeField] private GameObject _currentPos;

    [SerializeField] private List<DirectionType> _valideDirection;

    private Dictionary<int, List<GameObject>> posDict;

    public void InitPosReferences()
    {
        posDict = new Dictionary<int, List<GameObject>>();

        foreach (var pair in rowPair)
        {
            posDict[pair.RowNumber] = pair.PositionsList;
        }
        _valideDirection.Add(DirectionType.Right);
        _valideDirection.Add(DirectionType.Left);
        _valideDirection.Add(DirectionType.Back);


    }
    public void RemoveFromValideDirection(DirectionType directionType)
    {
        _valideDirection.Remove(directionType);
    }

    public void AddToValideDirection(DirectionType directionType)
    {
        if (!_valideDirection.Contains(directionType))
        {
            _valideDirection.Add(directionType);
        }
    }

    public void MonsterGoToThisRow(int newRow)
    {
        CurrentRow = newRow;
        if (posDict.TryGetValue(newRow, out var newPos))
        {
            MonsterMain.Instance.MonsterVisual.ChangeMonsterMesh(CurrentRow);
            transform.position = GetRandomPosFromRow(CurrentRow);
            MonsterMain.Instance.MonsterVisual.RotateToPlayer();
        }
    }

    public void MonsterMoveTowardPlayer()
    {
        AdvanceRow();
        MonsterMain.Instance.MonsterVisual.ChangeMonsterMesh(CurrentRow);
        transform.position = GetRandomPosFromRow(CurrentRow);
        MonsterMain.Instance.MonsterVisual.RotateToPlayer();
    }

    private void AdvanceRow()
    {
        if (CurrentRow > 1)
        {
            CurrentRow--;
        }
    }

    private Vector3 GetRandomPosFromRow(int row)
    {
        //list temporaire
        int _randomIndex = Random.Range(0, posDict[row].Count);
        _currentPos = posDict[row][_randomIndex];
        return _currentPos.transform.position;
    }

}
