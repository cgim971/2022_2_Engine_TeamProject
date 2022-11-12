using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCube : MonoBehaviour, IPoolable
{
    [SerializeField] private string objName;
    public string NAME { get => objName; set => objName = value; }

    public void OnPool()
    {
        Debug.Log(NAME);
        Invoke("PushObj", 3f);
    }

    public void PushObj() => PoolingManager.PushObject(NAME, this.gameObject);
}
