using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static MonsterVisual;

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

    private Dictionary<int, List<GameObject>> posDict;

    public void InitPosReferences()
    {
        posDict = new Dictionary<int, List<GameObject>>();

        foreach (var pair in rowPair)
        {
            posDict[pair.RowNumber] = pair.PositionsList;
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
        int _randomIndex = Random.Range(0, posDict[row].Count);
        _currentPos = posDict[row][_randomIndex];
        return _currentPos.transform.position;
    }

}
