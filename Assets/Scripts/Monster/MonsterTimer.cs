using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MonsterTimer : MonoBehaviour
{
    public float CurrentDelayBetweenActions;

    private Coroutine _timerCoroutine;
    public void StartTimer()
    {
        StopTimer();
        _timerCoroutine = StartCoroutine(TimerRoutine());
    }

    private void StopTimer()
    {
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }
    }

    private IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(CurrentDelayBetweenActions);

        DoAction();
        StartTimer();
    }

    private void DoAction()
    {
        if (MonsterMain.Instance.MonsterEncounter.IsWatchedByPlayer)
        {
            if (MonsterMain.Instance.MonsterEncounter.CheckIsSamePlayerMask())
            {
                MonsterMain.Instance.MonsterEncounter.Flee();
            }
            else
            {
                if (MonsterMain.Instance.MonsterMovement.CurrentRow != 1)
                {
                    MonsterMain.Instance.MonsterBrain.SwitchToNewMaskState(MonsterMain.Instance.MonsterBrain.GetRandomMaskState());
                    MonsterMain.Instance.MonsterMovement.MonsterMoveTowardPlayer();
                }
                else
                {
                    //MonsterMain.Instance.MonsterEncounter.KillPlayer();
                    MonsterMain.Instance.MonsterEncounter.Flee();
                }
            }
        }
        else
        {
            if (MonsterMain.Instance.MonsterMovement.CurrentRow != 1)
            {
                MonsterMain.Instance.MonsterBrain.SwitchToNewMaskState(MonsterMain.Instance.MonsterBrain.GetRandomMaskState());
                MonsterMain.Instance.MonsterMovement.MonsterMoveTowardPlayer();
            }
            else
            {
                //MonsterMain.Instance.MonsterEncounter.KillPlayer();
                MonsterMain.Instance.MonsterEncounter.Flee();
            }
        }

    }
}
