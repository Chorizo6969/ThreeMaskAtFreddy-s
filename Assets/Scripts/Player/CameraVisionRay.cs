using UnityEngine;

public class CameraVisionRay : MonoBehaviour
{

    [SerializeField] private DirectionType _lastDirectionLooked;
    [SerializeField] private DirectionLookDetector _lastComponent;
    void Update()
    {
        RaycastHit hitDirection;
        if (Physics.Raycast(transform.position, transform.forward, out hitDirection, 500, ~7))
        {
            Debug.Log("JE TOUCHE le trigger");
            if (hitDirection.transform.gameObject.TryGetComponent<DirectionLookDetector>(out DirectionLookDetector component))
            {

                component.IsWatched = true;
                _lastDirectionLooked = component.DirectionType;
                MonsterMain.Instance.MonsterMovement.RemoveFromValideDirection(_lastDirectionLooked);

            }
            else
            {
                MonsterMain.Instance.MonsterMovement.AddToValideDirection(_lastDirectionLooked);
                if (_lastComponent != null) _lastComponent.IsWatched = false;
            }
        }

        RaycastHit hitMonster;
        if (Physics.Raycast(transform.position, transform.forward, out hitMonster, 500, ~6))
        {
            Debug.Log("JE TOUCHE le monstre");
            MonsterMain.Instance.MonsterEncounter.IsWatchedByPlayer = true;
        }
        else
        {
            MonsterMain.Instance.MonsterEncounter.IsWatchedByPlayer = false;
        }

        Debug.DrawRay(transform.position, transform.forward * 500, Color.red);
    }
}
