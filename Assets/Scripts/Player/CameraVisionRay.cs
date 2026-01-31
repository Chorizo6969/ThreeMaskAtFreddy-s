using UnityEngine;

public class CameraVisionRay : MonoBehaviour
{

    void Update()
    {
        if(MonsterMain.Instance.gameObject != null)
        {
            RaycastHit hitDirection;
            if (Physics.Raycast(transform.position, transform.forward, out hitDirection, Mathf.Infinity, 1<<7))
            {
                //Debug.Log("JE TOUCHE le trigger");
                if (hitDirection.transform.gameObject.TryGetComponent<DirectionLookDetector>(out DirectionLookDetector component))
                {
                    component.IsWatchedByPlayer = true;

                }
            }

            RaycastHit hitMonster;
            if (Physics.Raycast(transform.position, transform.forward, out hitMonster, Mathf.Infinity, 1<<6))
            {
                //Debug.Log("JE TOUCHE le monstre");
                MonsterMain.Instance.MonsterEncounter.IsWatchedByPlayer = true;
            }
            else
            {
                MonsterMain.Instance.MonsterEncounter.IsWatchedByPlayer = false;
            }

            Debug.DrawRay(transform.position, transform.forward * 500, Color.red);
        }
    }

}
