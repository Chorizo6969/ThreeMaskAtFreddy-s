using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;
using System.Collections.Generic;

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
        float randomF = UnityEngine.Random.Range(-1f, 1f);
        yield return new WaitForSeconds(CurrentDelayBetweenActions + randomF);

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
                    MonsterMain.Instance.MonsterEncounter.KillPlayer();
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
                MonsterMain.Instance.MonsterEncounter.KillPlayer();
                StopTimer();
            }
        }
        SoundManager.Instance.PlayRandomMonsterSound();
        float randomF = UnityEngine.Random.Range(-0.2f, 0.2f);
        EffectManager.Instance.BlinkAllLane(1 + randomF);
        MonsterMain.Instance.MonsterVisual.CallHideMonster(randomF);

    }
}
