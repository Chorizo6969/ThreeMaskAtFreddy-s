using UnityEngine;

public class InteractRadio : MonoBehaviour
{
    [SerializeField] private Radio _radio;

    void Update()
    {
        OnRepair();
    }

    void OnRepair()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _radio.Repair();
            Debug.Log("Radio interacted with!");
        }
    }
}
