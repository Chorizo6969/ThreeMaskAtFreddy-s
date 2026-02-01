using UnityEngine;

public class MonsterSound : MonoBehaviour
{
    [SerializeField] AudioSource _growlSource;
    [SerializeField] AudioSource _movementSource;

    public void PlayGrowl(AudioClip growClip)
    {
        _growlSource.PlayOneShot(growClip);
    }


    public void PlayMovement(AudioClip growClip)
    {
        _movementSource.PlayOneShot(growClip);
    }

}
