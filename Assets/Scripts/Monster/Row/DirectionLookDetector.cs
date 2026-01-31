using UnityEngine;

public class DirectionLookDetector : MonoBehaviour
{
    public DirectionType DirectionType;
    public bool IsWatched = false;

    [SerializeField] private Renderer _renderer;

    private void Update()
    {
        if (MonsterMain.Instance != null)
        {
            if (!IsWatched)
            {
                if (!MonsterMain.Instance.MonsterMovement.ValideDirection.Contains(DirectionType))
                {
                    MonsterMain.Instance.MonsterMovement.AddToValideDirection(DirectionType);
                    _renderer.material.color = Color.black;
                }

            }
            else
            {
                if (MonsterMain.Instance.MonsterMovement.ValideDirection.Contains(DirectionType))
                {
                    MonsterMain.Instance.MonsterMovement.RemoveFromValideDirection(DirectionType);
                    _renderer.material.color = Color.red;
                }

            }
        }

    }
}
