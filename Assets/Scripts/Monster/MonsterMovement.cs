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

    public List<DirectionType> ValideDirection;

    private Dictionary<int, List<GameObject>> posDict;

    public void InitPosReferences()
    {
        posDict = new Dictionary<int, List<GameObject>>();

        foreach (var pair in rowPair)
        {
            posDict[pair.RowNumber] = pair.PositionsList;
        }
        SetupInitValideDirection();
    }

    void SetupInitValideDirection()
    {
        ValideDirection.Add(DirectionType.Right);
        ValideDirection.Add(DirectionType.Left);
        ValideDirection.Add(DirectionType.Back);
    }
    public void RemoveFromValideDirection(DirectionType directionType)
    {
        ValideDirection.Remove(directionType);
    }

    public void AddToValideDirection(DirectionType directionType)
    {
        if (!ValideDirection.Contains(directionType))
        {
            ValideDirection.Add(directionType);
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
        int _randomIndex = Random.Range(0, ValideDirection.Count);
        DirectionType _randomDirectionType = ValideDirection[_randomIndex];

        switch (_randomDirectionType)
            {
            case DirectionType.Right:
                _currentPos = posDict[row][0];
                break;
            case DirectionType.Left:
                _currentPos = posDict[row][1];
                break;
            case DirectionType.Back:
                _currentPos = posDict[row][2];
                break;
            }
            return _currentPos.transform.position;
    } 
}
