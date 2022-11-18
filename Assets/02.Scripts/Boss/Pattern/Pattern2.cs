using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private LineRenderer lr;
    private MeshRenderer mesh;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        MoveToPlayer();
        ShootLaser();
    }

    private void MoveToPlayer()
    {
        transform.DOMoveX(player.transform.position.x, 1f);
        Vector3 targetPos = player.transform.position;
    }

    private void ShowWarning()
    {
        mesh.material.color = new Color(0f, 0f, 0f);

        mesh.material.DOColor(Color.black, 2f).SetEase(Ease.Linear);


    }

    private void ShootLaser()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        Vector3 dir = Vector3.Normalize(player.transform.position - transform.position);

        if (Physics.Raycast(transform.position, dir, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        else
            lr.SetPosition(1, transform.forward * 5000);

        if (Physics.Raycast(transform.position, dir, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Hit");
            }
        }
    }

    private void CheckHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player hit");


            }
        }

    }

    private void HitDmg()
    {



    }
}
