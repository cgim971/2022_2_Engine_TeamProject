using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle_Base : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Obstacle");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }




}
