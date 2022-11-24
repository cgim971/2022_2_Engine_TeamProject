using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseDirObject : Object_Base
{
    public override void EffectStart(GameObject obj)
    {
        obj.GetComponentInParent<PlayerMovement_Base>().ReverseDir();
    }
    public override void EffectEnd(GameObject obj)
    {
    }
}
