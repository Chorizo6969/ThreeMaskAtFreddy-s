using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMask : MonoBehaviour
{
    [SerializeField] private PlayerAnim playerAnim;

    public int currentMask = -1; // -1 = aucun masque

    public MaskType CurrentMask = MaskType.Undefined;

    public List<MaskHandler> _maskHandlers = new();

    private bool _canSwitchMask = true;

    private IEnumerator Cooldown(float cooldown)
    {
        _canSwitchMask = false;
        yield return new WaitForSeconds(cooldown);
        _canSwitchMask = true;
    }

    private void Start()
    {
        UpdateMaskEnum();
    }

    public void EquipMask(int maskIndex)
    {
        if (_maskHandlers[maskIndex].IsAnim || !_canSwitchMask) return;
        if (currentMask != -1)
            RemoveMask();

        currentMask = maskIndex;
        UpdateMaskEnum();
        _maskHandlers[maskIndex].SlideOnEquip();
    }

    public void RemoveMask()
    {
        if (currentMask == -1) return;

        _maskHandlers[currentMask].OnDesequip();
        currentMask = -1;
        UpdateMaskEnum();
        StartCoroutine(Cooldown(0.7f));
    }

    private void UpdateMaskEnum()
    {
        switch (currentMask)
        {
            case 0:
                CurrentMask = MaskType.Red;
                break;

            case 1:
                CurrentMask = MaskType.Green;
                break;

            case 2:
                CurrentMask = MaskType.Blue;
                break;

            default:
                CurrentMask = MaskType.Undefined;
                break;
        }
    }
}