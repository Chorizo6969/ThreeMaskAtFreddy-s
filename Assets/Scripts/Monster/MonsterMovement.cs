using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    [System.Serializable]
    public class Row
    {
        public List<GameObject>positionsList;
    }

    [SerializeField] private List<Row> rows;

    [SerializeField] private int _currentRow;
    [SerializeField] private GameObject _currentPos;


    public void MonsterMoveTo(int pos)
    {
        MonsterMain.Instance.MonsterVisual.ChangeMonsterMesh(pos);
    }

    //public void MonsterFlee()
    //{
    //    transform.position = GetRandom3Pos();
    //}

    //private List<GameObject> GetNextPosList()
    //{
    //    return _pos3List; //ici a finir
    //}

    private Vector3 GetRandomPosFromList(List<GameObject> posList)
    {
        int randomIndex = Random.Range(0, posList.Count);
        return posList[randomIndex].transform.position;
    }

    //private Vector3 GetRandom3Pos()
    //{
    //    int randomIndex = Random.Range(0, _pos3List.Count);
    //    return _pos3List[randomIndex].transform.position;

    //}



}
