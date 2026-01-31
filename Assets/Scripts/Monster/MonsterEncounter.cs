using UnityEngine;

public class MonsterEncounter : MonoBehaviour
{


    public void CheckPlayerMask()
    {
        // look same direction && same mask Flee
        // else Kill player
        Flee();
    }

    private void KillPlayer()
    {

    }

    private void Flee()
    {
        MonsterMain.Instance.MonsterMovement.MonsterGoToThisRow(3);
    }
}
