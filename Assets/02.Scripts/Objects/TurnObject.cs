using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObject : Object_Base
{
    public override void EffectStart(GameObject obj)
    {
        obj.GetComponentInParent<PlayerMovement_Base>().TurnObject();
    }
    public override void EffectEnd(GameObject obj) { }
}
