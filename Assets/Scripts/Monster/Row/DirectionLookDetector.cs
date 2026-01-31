using UnityEngine;

public class DirectionLookDetector : MonoBehaviour
{
    public DirectionType DirectionType;
    public bool IsWatched = false;

    [SerializeField] private Renderer _renderer;

    private void Update()
    {
        if (!IsWatched)
        {
            _renderer.material.color = Color.black;
        }
        else
        {
            _renderer.material.color = Color.red;
        }
    }
}
