using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class MaskHandler : MonoBehaviour
{
    private Vector3 _tableBasePos;
    private Vector3 _playerBasePos;

    [SerializeField] Color _maskColor;
    [SerializeField] private Transform _playerHeadSocket;
    [SerializeField] private GameObject _tableMask;
    [SerializeField] private GameObject _playerMask;

    public bool IsAnim;

    private void Awake()
    {
        _tableBasePos = _tableMask.transform.position;
        _playerBasePos = _playerMask.transform.position;
    }

    public void SlideOnEquip()
    {
        IsAnim = true;
        Sequence sequence = DOTween.Sequence().Pause();
        sequence
            .Append(_tableMask.transform.DOMoveZ(-1.5f, 0.3f))
            .Append(_playerMask.transform.DOMove(_playerHeadSocket.position, 0.5f).SetEase(Ease.OutCubic))
            .AppendCallback(() => EffectManager.Instance.MaskVignetteFocus(_maskColor))
            .OnComplete(() => IsAnim = false);

        sequence.Play();
        SoundManager.Instance.PlayMaskSound();
    }

    public void OnDesequip()
    {
        SoundManager.Instance.PlayMaskSound();
        IsAnim = true;
        Sequence sequence = DOTween.Sequence().Pause();
        sequence
            .AppendCallback(() => EffectManager.Instance.ResetVignette())
            .Append(_playerMask.transform.DOMove(_playerBasePos, 0.6f))
            .Append(_tableMask.transform.DOMoveZ(_tableBasePos.z, 0.3f))
            .OnComplete(() => IsAnim = false);

        sequence.Play();
    }
}
