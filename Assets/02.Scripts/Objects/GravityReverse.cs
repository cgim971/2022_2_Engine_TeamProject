using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverse : MonoBehaviour
{
    private bool _useFlag = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_useFlag)
        {
            _useFlag = true;
            other.GetComponentInParent<CustomGravity>().SetGravity();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _useFlag)
        {
            _useFlag = false;
        }
    }
}
