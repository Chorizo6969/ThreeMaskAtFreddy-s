using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterEncounter : MonoBehaviour
{
    public bool IsWatchedByPlayer;
    

    [SerializeField] private float delayToRemoveEachFlee = 1f;

    public bool CheckIsSamePlayerMask()
    {
        if(PlayerMain.Instance.PlayerMask.CurrentMask == MonsterMain.Instance.MonsterBrain.CurrentMask) return true;
        else return false;
    }

    public async Task KillPlayer()
    {
        SessionHandler.Instance.StopTheGame();
        PlayerMain.Instance.PlayerMask.RemoveMask();
        await Screamer();
        UIManager.Instance.ShowGameOverPanel();
    }

    public void Flee()
    {
        MonsterMain.Instance.MonsterBrain.SwitchToNewMaskState(MonsterMain.Instance.MonsterBrain.GetRandomMaskState());
        MonsterMain.Instance.MonsterMovement.MonsterGoToThisRow(3);
        if(MonsterMain.Instance.MonsterTimer.CurrentDelayBetweenActions > 4f) MonsterMain.Instance.MonsterTimer.CurrentDelayBetweenActions = MonsterMain.Instance.MonsterTimer.CurrentDelayBetweenActions - delayToRemoveEachFlee;
    }

    public async UniTask Screamer()
    {
        PlayerMain.Instance.transform.DORotateQuaternion(Quaternion.LookRotation(MonsterMain.Instance.transform.position - PlayerMain.Instance.transform.position), 0.2f);
        await UniTask.Delay(200);
        MonsterMain.Instance.transform.Rotate(Vector3.up, 0.05f);
        MonsterMain.Instance.transform.DOMove(PlayerMain.Instance.MonsterScreamerSocket.transform.position, 0.1f);
        MonsterMain.Instance.transform.DOPunchScale(Vector3.one * 0.6f, 1f, 500, 5);
        SoundManager.Instance.PlayerJumpscare();
        await UniTask.Delay(1000);
    }
}
