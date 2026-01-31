using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    //[SerializeField] private Animator animator;

    public void PlayEquipMask(int maskIndex)
    {
        #region V1 de merde
        //animator.speed = 1f;
        //animator.SetFloat("MaskIndex", maskIndex);
        //animator.SetBool("IsWearing", true);
        //animator.Play("TakesMask", 0, 0f);

        #endregion
    }

    public void PlayRemoveMask(int maskIndex)
    {
        #region V1 de merde
        //animator.SetFloat("MaskIndex", maskIndex);
        //animator.SetBool("IsWearing", false);
        //animator.Play("TakesMask", 0, 1f);
        //animator.Update(0f);
        //animator.speed = -1f;
        #endregion
    }
}