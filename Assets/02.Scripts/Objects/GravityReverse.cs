using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverse : MonoBehaviour
{
    private bool _useFlag = false;
    [SerializeField] private bool _moreUse = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_useFlag)
        {
            _useFlag = true;
            other.GetComponentInParent<CustomGravity>().SetGravity();
            other.GetComponentInParent<PlayerMovement>().JUMPEXTRACOUNT = 0;
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
