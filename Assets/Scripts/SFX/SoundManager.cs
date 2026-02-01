using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance => instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource _audioSource;

    [Header("Clip")]
    [SerializeField] private AudioClip _equipMask;
    [SerializeField] private AudioClip _radioBug;
    [SerializeField] private AudioClip _jumpscareClip;
    [SerializeField] private AudioClip _lightOffClip;

    [Header("List Sound")]
    [SerializeField] private List<AudioClip> _audioTerrifingSFXList;
    [SerializeField] private List<AudioClip> _eachSecondsSFXList;
    [SerializeField] private List<AudioClip> _radioRepairSFXList;
    public List<AudioClip> MonsterMoveSFXList;
    public List<AudioClip> MonsterGrowlSFXList;

    private CancellationTokenSource _radioCTS;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        PlayRandomSound().Forget();
        PlayRandomAmbianceSound().Forget();
    }

    //------------------------------------------------BigSound

    private async UniTask PlayRandomAmbianceSound()
    {
        while (true)
        {
            int soundIndex = Random.Range(0, _eachSecondsSFXList.Count - 1);
            _audioSource.PlayOneShot(_eachSecondsSFXList[soundIndex]);

            await UniTask.WaitForSeconds(3);
        }
    }

    //------------------------------------------------ WATER

    private async UniTask PlayRandomSound()
    {
        while (true)
        {
            int soundIndex = Random.Range(0, _audioTerrifingSFXList.Count - 1);
            _audioSource.PlayOneShot(_audioTerrifingSFXList[soundIndex]);

            int time = Random.Range(10, 30);
            await UniTask.WaitForSeconds(time);
        }
    }

    //----------------------------------------------- RADIO SOUND

    public void PlayRadioSound()
    {
        _radioCTS = new CancellationTokenSource();
        LoopRadioSound(_radioCTS.Token).Forget();
        _audioSource.clip = _radioBug;
        _audioSource.Play();
    }

    private async UniTask LoopRadioSound(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            int soundIndex = Random.Range(0, _radioRepairSFXList.Count - 1);
            _audioSource.PlayOneShot(_radioRepairSFXList[soundIndex]);

            await UniTask.WaitForSeconds(2, cancellationToken: token);
        }
    }

    public void StopRadioSound()
    {
        _audioSource?.Stop();
        _radioCTS?.Cancel();
        _radioCTS?.Dispose();
    }

    //---------------------------------------------------------------------- Mask Sound

    public void PlayMaskSound() => _audioSource.PlayOneShot(_equipMask);

    //---------------------------------------------------------------------- Monstre

    public void PlayRandomMonsterSound() => _audioSource.PlayOneShot(MonsterMoveSFXList[Random.Range(0, MonsterMoveSFXList.Count - 1)]); //déplacement

    public void PlayGrawlMonsterSound() => _audioSource.PlayOneShot(MonsterMoveSFXList[Random.Range(0, MonsterGrowlSFXList.Count - 1)]); //grognement

    public AudioClip GetRandomSoundFromList(List<AudioClip> audioList)
    {
        int randomIndex = Random.Range(0, audioList.Count);
        AudioClip randomAudio = audioList[randomIndex];
        return randomAudio;
    }

    public void PlayerJumpscare() => _audioSource.PlayOneShot(_jumpscareClip);

    public void ChangeLightSound() => _audioSource.PlayOneShot(_lightOffClip);
}
