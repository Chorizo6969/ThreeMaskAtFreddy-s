using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator _animator;
    private float _currentSpeed;

    public float GetCurrentSpeed() => _currentSpeed;

    public void SetTakesMask(float index, int speed)
    {
        _currentSpeed = index;
        _animator.SetFloat("MaskTakesIndex", index);
    }

    public void SetWearMask(float index, int speed)
    {
        _currentSpeed = index;
        _animator.SetFloat("MaskWearIndex", index);
    }
}
