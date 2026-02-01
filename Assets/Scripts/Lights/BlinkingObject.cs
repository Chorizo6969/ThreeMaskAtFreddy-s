using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    [SerializeField] private Behaviour _componentToBlink;
    [SerializeField] private GameObject _objectToBlink;
    [SerializeField] private float _minDelay, _maxDelay;
    [SerializeField] private bool _blinkOnStart;

    /// <summary>
    /// Turns the light on or off on choice.
    /// </summary>
    /// <param name="active"></param>
    public void TurnLight(bool active)
    {
        _componentToBlink.enabled = active;
        _objectToBlink.SetActive(active);
    }

    public void TurnInfiniteBlink(bool active)
    {
        if (active)
        {
            StartCoroutine(InfiniteBlink());
        }
        else
        {
            StopCoroutine(InfiniteBlink());
        }
    }

    /// <summary>
    /// Turns off light for a time then turn it on back.
    /// </summary>
    /// <param name="duration">The duration (in seconds) the light will stay off.</param>
    public void CallBlinkOnce(float duration) => StartCoroutine(BlinkOnce(duration));

    private IEnumerator InfiniteBlink()
    {
        while (true)
        {
            TurnLight(true);
            yield return new WaitForSeconds(0.2f);
            TurnLight(false);
            yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        }
    }

    private IEnumerator BlinkOnce(float duration)
    {
        TurnLight(false);
        yield return new WaitForSeconds(duration);
        TurnLight(true);
    }
}
