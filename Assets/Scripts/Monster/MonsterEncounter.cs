using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading.Tasks;
using Unity.Cinemachine;
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

    public async UniTask KillPlayer()
    {
        Debug.Log("Kill");
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
        PlayerMain.Instance.PlayerMovement.UpdateCamera(MonsterMain.Instance.MonsterMovement.GetCurrentDirection().Item2);
        await UniTask.Delay(100);
        MonsterMain.Instance.transform.DOMove(MonsterMain.Instance.transform.position + MonsterMain.Instance.transform.forward * 6f + Vector3.up * 0.8f, 0.1f);
        MonsterMain.Instance.transform.DOPunchScale(Vector3.one * 0.45f, 1f, 500, 5);

        SoundManager.Instance.PlayerJumpscare();
        await UniTask.Delay(1500);
    }
}
