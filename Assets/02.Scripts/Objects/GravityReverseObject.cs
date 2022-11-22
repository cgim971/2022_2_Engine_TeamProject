using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverseObject : Object_Base
{
    public override void EffectStart(GameObject obj)
    {
        obj.GetComponentInParent<CustomGravity>().ReverseGravity();
        obj.GetComponentInParent<PlayerMovement_Base>().JUMPEXTRACOUNT = 0;
    }
    public override void EffectEnd(GameObject obj) { }
}
