using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    [SerializeField] private float _goal = 1f;
    [SerializeField] private Slider _slider;
    public float Current = 0f;

    public void Repair()
    {
        Current += 0.0003f;
        _slider.value = Current;

        if (Current >=_goal)
        {
            Current = _goal;
            //Victoire
        }
    }
}
