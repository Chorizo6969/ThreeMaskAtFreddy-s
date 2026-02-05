using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.VFX;
using System.Collections;

public class Radio : MonoBehaviour
{
    [SerializeField] private float _repairTime = 120f;
    [SerializeField] private Slider _slider;
    [SerializeField] private ParticleSystem _electricityVFX;

    public float Current = 0f;

    public void Repair()
    {
        if (!SessionHandler.Instance.GameStarted) return;
        Current += Time.deltaTime;
        _slider.value = Current / _repairTime;

        if (Current >=_repairTime)
        {
            Current = _repairTime;
            UIManager.Instance.ShowWinPanel();
            SessionHandler.Instance.StopTheGame();
        }
    }

    public void PlayElectricityVFX()
    {
        _electricityVFX.Play();
        //Jitter();
    }

    public void Jitter()
    {
        StartCoroutine(JitterCoroutine());
    }

    private IEnumerator JitterCoroutine()
    {
        this.transform.DOPunchPosition(Vector3.one * 0.01f, 0.2f, 20);
        yield return new WaitForSeconds(0.8f);
    }
}
