using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Player_BaseMovement : MonoBehaviour
{
    protected Rigidbody rb;
    protected Camera camera = null;

    protected Vector3 dir = Vector3.forward;
    protected Vector3 rot = Vector3.forward;

    protected bool isClick = false;

    protected float speed = 4f;
    protected float rotSpeed = 4f;
    protected float jumpHeight = 4f;

    protected LayerMask groundLayer;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;

        groundLayer = LayerMask.GetMask("Ground");
    }

    protected abstract IEnumerator PlayerMoveState();

    protected Vector3 GetScreenPosition()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = camera.farClipPlane;
        return pos;
    }
    protected bool CheckGround()
    {
        if (Physics.Raycast(transform.position - (Vector3.up * 0.2f), Vector3.down, out RaycastHit hit, 0.4f, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
