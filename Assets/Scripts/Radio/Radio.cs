using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField] private float Goal = 1f;
    public float Current = 0f;

    public void Repair()
    {
        Current += 0.0003f;

        if (Current >= Goal)
        {
            Current = Goal;
            //Victoire
        }
    }
}
