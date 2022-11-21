using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : Object_Base
{
    public override void EffectStart(GameObject obj)
    {
        obj.GetComponentInParent<PlayerMovement_Base>().Jumping();
    }
    public override void EffectEnd(GameObject obj) { }
}
