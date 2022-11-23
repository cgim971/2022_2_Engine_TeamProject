using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle_Base : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Obstacle");

            if (IsUp()) return;

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }



    }

    private bool IsUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.up, out hit))
        {
            if(hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }



        return false;
    }
}
