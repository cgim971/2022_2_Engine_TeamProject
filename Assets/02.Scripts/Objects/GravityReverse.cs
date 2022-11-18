using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverse : MonoBehaviour
{
    private bool useFlag = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !useFlag)
        {
            useFlag = true;
            other.GetComponentInParent<CustomGravity>().SetGravity();
        }
    }
}
