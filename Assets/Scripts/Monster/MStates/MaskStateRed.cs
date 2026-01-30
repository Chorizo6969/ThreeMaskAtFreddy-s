using UnityEngine;

public class MaskStateRed : MaskState
{
    public override MaskType MaskType => MaskType.Red;
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
