using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    [SerializeField] Behaviour _componentToBlink;
    [SerializeField] GameObject _objectToBlink;
    [SerializeField] float _minDelay, _maxDelay;

    public IEnumerator Start()
    {
        while (true)
        {
            _componentToBlink.enabled = true;
            _objectToBlink.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _componentToBlink.enabled = false;
            _objectToBlink.SetActive(false);
            yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        }
    }
}
