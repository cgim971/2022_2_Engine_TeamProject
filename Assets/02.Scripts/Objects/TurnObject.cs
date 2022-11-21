using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObject : MonoBehaviour
{
    private bool _useFlag = false;
    [SerializeField] private bool _moreUse = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_useFlag)
        {
            _useFlag = true;
            other.GetComponentInParent<PlayerMovement_Base>().TurnObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _useFlag && _moreUse)
        {
            _useFlag = false;
        }
    }
}
