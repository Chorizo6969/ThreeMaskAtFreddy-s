using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance => instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> _soundList;

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
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(int soundIndex)
    {
        if (soundIndex < 0 || soundIndex >= _soundList.Count) return;
        audioSource.clip = _soundList[soundIndex];
        audioSource.Play();
    }
}
