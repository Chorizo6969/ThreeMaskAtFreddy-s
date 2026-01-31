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
        Debug.Log("GameOver");
    }

    private void Flee()
    {
        MonsterMain.Instance.MonsterBrain.SwitchToNewMaskState(MonsterMain.Instance.MonsterBrain.GetRandomMaskState());
        MonsterMain.Instance.MonsterMovement.MonsterGoToThisRow(3);
    }
}
