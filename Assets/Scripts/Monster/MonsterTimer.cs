using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MonsterTimer : MonoBehaviour
{
    public float DelayBetweenActions;

    private Coroutine _timerCoroutine;

    private void Start()
    {
        DelayBetweenActions = MonsterMain.Instance.DefaultDelayBetweenActions;
    }
    private void OnEnable()
    {
        StartTimer();
    }

    private void OnDisable()
    {
        StopTimer();
    }

    public void StartTimer()
    {
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
        yield return new WaitForSeconds(DelayBetweenActions);

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

    }
}
