using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRing : Object_Base
{
    public override void EffectStart(GameObject obj)
    {
        obj.GetComponentInParent<PlayerMovement_Base>().JUMPEXTRACOUNT += 1;
    }
    public override void EffectEnd(GameObject obj) { }
}
