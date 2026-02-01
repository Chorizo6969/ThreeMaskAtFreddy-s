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
        if (!SessionHandler.Instance.GameStarted) return;
        StopTimer();
        _timerCoroutine = StartCoroutine(TimerRoutine());
    }

    public void StopTimer()
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
        if (!SessionHandler.Instance.GameStarted) return;
        float randomF = UnityEngine.Random.Range(-0.2f, 0.2f);
        if (MonsterMain.Instance.MonsterMovement.CurrentRow == 1) EffectManager.Instance.BlinkAllLight(1 + randomF);
        else EffectManager.Instance.BlinkAllLane(1 + randomF);
        MonsterMain.Instance.MonsterVisual.CallHideMonster(randomF);
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
            }
        }
        MonsterMain.Instance.MonsterSound.PlayGrowl(SoundManager.Instance.GetRandomSoundFromList(SoundManager.Instance.MonsterGrowlSFXList));
        MonsterMain.Instance.MonsterSound.PlayMovement(SoundManager.Instance.GetRandomSoundFromList(SoundManager.Instance.MonsterMoveSFXList));
    }
}
