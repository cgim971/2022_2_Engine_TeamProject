using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<CustomGravity>().gravityScale *= -1f;
        }
    }
}
