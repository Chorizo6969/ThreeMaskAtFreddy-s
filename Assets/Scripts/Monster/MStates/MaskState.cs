using UnityEngine;

public abstract class MaskState : MonoBehaviour
{

    public abstract MaskType MaskType { get; }
    public virtual void OnEnter() 
    {
        MonsterMain.Instance.CurrentMask = MaskType;
    }

    public virtual void Do() { }

    public virtual void FixedDo() { }

    public virtual void OnExit() { }
}
