using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySetObject : Object_Base
{
    [SerializeField] private Vector3 _gravity = Vector3.zero;
    public override void EffectStart(GameObject obj)
    {
        obj.GetComponentInParent<CustomGravity>().SetGravity(_gravity);
        obj.GetComponentInParent<PlayerController>().transform.position = transform.position;
        obj.GetComponentInParent<PlayerMovement_Base>().JUMPEXTRACOUNT = 0;
    }
    public override void EffectEnd(GameObject obj) { }
}
