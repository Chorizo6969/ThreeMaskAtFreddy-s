using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TransitionGame : MonoBehaviour
{
    [SerializeField] private Image _panel;
    [SerializeField] private float _fadeDuration;

    public static TransitionGame Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _panel.gameObject.SetActive(true);
        _panel.DOFade(0f, _fadeDuration).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            _panel.gameObject.SetActive(false);
        });
    }

    public void CloseScene()
    {
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1f, _fadeDuration).SetEase(Ease.OutSine);
    }
}
