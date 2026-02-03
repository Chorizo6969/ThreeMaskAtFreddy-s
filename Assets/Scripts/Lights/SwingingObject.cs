using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SwingingObject : MonoBehaviour
{
    [SerializeField] private Vector3 _minRotationOffset, _maxRotationOffset;
    [SerializeField] private float _swingDuration;
    [SerializeField] private Ease _swingEase;

    private IEnumerator Start()
    {
        while (true)
        {
            this.transform.DORotate(_maxRotationOffset, _swingDuration).SetEase(_swingEase);
            yield return new WaitForSeconds(_swingDuration);
            this.transform.DORotate(_minRotationOffset, _swingDuration).SetEase(_swingEase);
            yield return new WaitForSeconds(_swingDuration);
        }
    }
}
