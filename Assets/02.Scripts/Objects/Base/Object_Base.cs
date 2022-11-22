using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_Base : MonoBehaviour
{
    private bool _useFlag = false;
    [SerializeField] private bool _moreUse = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_useFlag)
        {
            _useFlag = true;
            EffectStart(other.gameObject);
        }
        }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _useFlag && _moreUse)
        {
            _useFlag = false;
            EffectEnd(other.gameObject);
        }
    }

    public abstract void EffectStart(GameObject obj);
    public abstract void EffectEnd(GameObject obj);
}
