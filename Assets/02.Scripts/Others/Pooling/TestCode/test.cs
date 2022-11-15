using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        PoolingManager.CreatePool("Chanhee", this.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = PoolingManager.PopObject("Chanhee");
            obj.transform.position = Vector3.zero;
        }
    }
}
