using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransObject : Object_Base
{
    public override void EffectStart(GameObject obj)
    {
        Debug.Log("������Ʈ ����");
    }
    public override void EffectEnd(GameObject obj) { }
}
