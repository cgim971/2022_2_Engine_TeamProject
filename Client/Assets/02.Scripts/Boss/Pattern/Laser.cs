using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;

    [SerializeField] private Transform player;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        Vector3 dir = Vector3.Normalize(player.position - transform.position);

        if (Physics.Raycast(transform.position, dir, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        else
            lr.SetPosition(1, transform.forward * 5000);

        
    }
}

