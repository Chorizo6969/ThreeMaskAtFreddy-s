using UnityEngine;

public class MonsterEncounter : MonoBehaviour
{
    public bool IsWatchedByPlayer;

    public bool CheckIsSamePlayerMask()
    {
        //return false if not, if yes, return true
        return true;
    }

    public void KillPlayer()
    {
        Debug.Log("GameOver, playerDead");
    }

    public void Flee()
    {
        MonsterMain.Instance.MonsterBrain.SwitchToNewMaskState(MonsterMain.Instance.MonsterBrain.GetRandomMaskState());
        MonsterMain.Instance.MonsterMovement.MonsterGoToThisRow(3);
        if(MonsterMain.Instance.MonsterTimer.DelayBetweenActions > 4f) MonsterMain.Instance.MonsterTimer.DelayBetweenActions = MonsterMain.Instance.MonsterTimer.DelayBetweenActions - 0.4f;
        //La lampe du bureau clignote, le monstre se casse
    }
}
