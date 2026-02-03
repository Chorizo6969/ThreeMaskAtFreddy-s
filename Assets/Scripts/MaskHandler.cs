using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class MaskHandler : MonoBehaviour
{
    private Vector3 _tableBasePos;
    private Vector3 _playerBasePos;
    private Color _baseEmissive;

    [SerializeField] Color _maskColor;
    [SerializeField] private Transform _playerHeadSocket;
    [SerializeField] private GameObject _tableMask;
    [SerializeField] private MeshRenderer _playerMask;

    public bool IsAnim;

    private void Awake()
    {
        _tableBasePos = _tableMask.transform.position;
        _playerBasePos = _playerMask.transform.position;
        _baseEmissive = _playerMask.material.GetColor("_Emissive");
        _playerMask.material.SetColor("_Emissive", Color.black);
        _playerMask.material.SetFloat("_Alpha", 0);
        _playerMask.enabled = false;
    }

    public void SlideOnEquip()
    {
        IsAnim = true;
        Sequence sequence = DOTween.Sequence().Pause();
        sequence
            .Append(_tableMask.transform.DOMoveZ(-1.5f, 0.3f))
            .AppendCallback(() => _playerMask.enabled = true)
            .Insert(0.2f, _playerMask.material.DOColor(_baseEmissive, "_Emissive", 0.6f))
            .Insert(0.6f, _playerMask.material.DOFloat(0.2f, "_Alpha", 0.45f))
            .InsertCallback(0.45f, () => EffectManager.Instance.MaskVignetteFocus(_maskColor))
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
            .Append(_playerMask.material.DOFloat(0, "_Alpha", 0.6f))
            .Insert(0.2f, _playerMask.material.DOColor(Color.black, "_Emissive", 0.6f))
            .InsertCallback(0.6f, () => _playerMask.enabled = false)
            .Append(_tableMask.transform.DOMoveZ(_tableBasePos.z, 0.3f))
            .OnComplete(() => IsAnim = false);

        sequence.Play();
    }
}
