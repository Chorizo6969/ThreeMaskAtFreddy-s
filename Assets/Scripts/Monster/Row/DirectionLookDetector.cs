using UnityEngine;

public class DirectionLookDetector : MonoBehaviour
{
    public DirectionType DirectionType;
    public bool IsWatchedByPlayer = false;

    [SerializeField] private Renderer _renderer;

    private void Update()
    {
        if (MonsterMain.Instance.gameObject != null)
        {
            if (!IsWatchedByPlayer)
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
                IsWatchedByPlayer = false;

            }
        }

    }
}
