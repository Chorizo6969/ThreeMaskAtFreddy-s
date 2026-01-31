using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [System.Serializable]
    public class Row
    {
        public List<GameObject> positionsList;
    }

    [SerializeField] private List<Row> rows;
    [SerializeField] private int _currentRowListIndex; 
    [SerializeField] private GameObject _currentPos;

    public void MonsterGoToThisRow(int _row)
    {
        int _meshNumber = _row;
        _currentRowListIndex = _row - 1;
        MonsterMain.Instance.MonsterVisual.ChangeMonsterMesh(_meshNumber);
        transform.position = GetRandomPosFromRow(rows[_row-1].positionsList);
        MonsterMain.Instance.MonsterVisual.RotateToPlayer();
    }

    public void MonsterMoveTowardPlayer()
    {
        AdvanceRow();
        int _meshNumber = _currentRowListIndex + 1; 
        MonsterMain.Instance.MonsterVisual.ChangeMonsterMesh(_meshNumber);
        transform.position = GetRandomPosFromRow(rows[_currentRowListIndex].positionsList);
        MonsterMain.Instance.MonsterVisual.RotateToPlayer();
    }

    private void AdvanceRow()
    {
        if (_currentRowListIndex > 0)
        {
            _currentRowListIndex--;
        }
    }

    private Vector3 GetRandomPosFromRow(List<GameObject> _posList)
    {
        int _randomIndex = Random.Range(0, _posList.Count);
        _currentPos = _posList[_randomIndex];
        return _currentPos.transform.position;
    }

}
