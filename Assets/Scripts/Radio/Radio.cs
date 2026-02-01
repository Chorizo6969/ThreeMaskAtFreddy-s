using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Radio : MonoBehaviour
{
    [SerializeField] private float _repairTime = 120f;
    [SerializeField] private Slider _slider;
    public float Current = 0f;

    public void Repair()
    {
        Current += Time.deltaTime;
        _slider.value = Current / _repairTime;

        if (Current >=_repairTime)
        {
            Current = _repairTime;
            UIManager.Instance.ShowWinPanel();
        }
    }
}
