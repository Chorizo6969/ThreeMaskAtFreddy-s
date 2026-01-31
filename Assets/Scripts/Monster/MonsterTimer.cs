using UnityEngine;
using System.Collections;

public class MonsterTimer : MonoBehaviour
{
    [SerializeField] private float delayBetweenActions = 5f;

    private Coroutine _timerCoroutine;

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
        yield return new WaitForSeconds(delayBetweenActions);

        DoAction();
        StartTimer();
    }

    private void DoAction()
    {
        MonsterMain.Instance.MonsterBrain.SwitchToNewMaskState(MonsterMain.Instance.MonsterBrain.GetRandomMaskState());
        MonsterMain.Instance.MonsterMovement.MonsterMoveTowardPlayer();
    }
}
