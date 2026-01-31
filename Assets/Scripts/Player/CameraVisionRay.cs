using UnityEngine;

public class CameraVisionRay : MonoBehaviour
{

    [SerializeField] private DirectionType lastDirectionLooked;
    void Update()
    {
        RaycastHit hitDirection;
        if(Physics.Raycast(transform.position, transform.forward, out hitDirection, 7))
        {
            hitDirection.transform.gameObject.TryGetComponent<DirectionLookDetector>(out DirectionLookDetector component);
            lastDirectionLooked = component.DirectionType;
            MonsterMain.Instance.MonsterMovement.RemoveFromValideDirection(lastDirectionLooked);
        }
        else
        {
            MonsterMain.Instance.MonsterMovement.AddToValideDirection(lastDirectionLooked);
        }

        RaycastHit hitMonster;
        if (Physics.Raycast(transform.position, transform.forward, out hitMonster, 6))
        {
            MonsterMain.Instance.IsWatchedByPlayer = true;
        }
        else
        {
            MonsterMain.Instance.IsWatchedByPlayer = false;
        }

    }
}
