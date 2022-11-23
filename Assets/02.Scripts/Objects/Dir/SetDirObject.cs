using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirObject : Object_Base
{
    [SerializeField] Vector3 _dir = Vector3.zero;
    [SerializeField] Vector3 _gravity = Vector3.zero;

    public override void EffectStart(GameObject obj)
    {
        obj.GetComponentInParent<PlayerMovement_Base>().SetDir(_dir, _gravity);
    }
    public override void EffectEnd(GameObject obj) { }

}
