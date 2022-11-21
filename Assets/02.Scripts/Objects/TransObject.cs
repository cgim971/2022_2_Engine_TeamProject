using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransObject : Object_Base
{
    public override void EffectStart(GameObject obj)
    {
        Debug.Log("오브젝트 변경");
    }
    public override void EffectEnd(GameObject obj) { }
}
