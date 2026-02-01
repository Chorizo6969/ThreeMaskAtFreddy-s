using UnityEngine;

public class MonsterEncounter : MonoBehaviour
{
    public bool IsWatchedByPlayer;

    [SerializeField] private float delayToRemoveEachFlee = 0.4f;

    public bool CheckIsSamePlayerMask()
    {
        if(PlayerMain.Instance.PlayerMask.CurrentMask == MonsterMain.Instance.MonsterBrain.CurrentMask) return true;
        else return false;

    }

    public void KillPlayer()
    {
        Debug.Log("GameOver, playerDead");
    }

    public void Flee()
    {
        MonsterMain.Instance.MonsterBrain.SwitchToNewMaskState(MonsterMain.Instance.MonsterBrain.GetRandomMaskState());
        MonsterMain.Instance.MonsterMovement.MonsterGoToThisRow(3);
        if(MonsterMain.Instance.MonsterTimer.CurrentDelayBetweenActions > 4f) MonsterMain.Instance.MonsterTimer.CurrentDelayBetweenActions = MonsterMain.Instance.MonsterTimer.CurrentDelayBetweenActions - delayToRemoveEachFlee;
    }
}
