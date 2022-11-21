using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverse : Object_Base
{
    public override void EffectStart(GameObject obj)
    {
        obj.GetComponentInParent<CustomGravity>().SetGravity();
        obj.GetComponentInParent<PlayerMovement_Base>().JUMPEXTRACOUNT = 0;
    }
    public override void EffectEnd(GameObject obj) { }
}
