using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransObject : Object_Base
{
    [SerializeField] private PlayerMode _playerMode = PlayerMode.NONE;
    public override void EffectStart(GameObject obj)
    {
        Debug.Log("A");
        obj.GetComponentInParent<PlayerController>().TransMode(_playerMode);
    }
    public override void EffectEnd(GameObject obj) { }
}
