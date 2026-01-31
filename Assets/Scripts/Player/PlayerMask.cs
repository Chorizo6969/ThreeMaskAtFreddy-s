using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMask : MonoBehaviour
{
    [SerializeField] private PlayerAnim playerAnim;

    private int currentMask = -1; // -1 = aucun masque

    public void EquipMask(int maskIndex)
    {
        if (currentMask != -1)
            RemoveMask();

        currentMask = maskIndex;
        playerAnim.PlayEquipMask(maskIndex);
    }

    public void RemoveMask()
    {
        if (currentMask == -1) return;

        playerAnim.PlayRemoveMask(currentMask);
        currentMask = -1;
    }
}