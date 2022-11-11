using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private Camera camera = null;

    private Vector3 dir = Vector3.forward;
    private Vector3 rot = Vector3.forward;

    private bool isClick = false;

    public float speed = 4f;
    public float rotSpeed = 4f;
    public float jumpHeight = 4f;

    private LayerMask groundLayer;
    Coroutine clickCheckCoroutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;

        groundLayer = LayerMask.GetMask("Ground");

        StartCoroutine(PlayerState());
    }

    private void FixedUpdate()
    {
        // 회전 코드 필요

        rb.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (CheckGround())
        {
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rb.AddForce(jumpPower, ForceMode.VelocityChange);
        }
    }

    private IEnumerator CheckClick()
    {
        yield return new WaitForSeconds(0.3f);
        if (isClick == true) isClick = false;
    }

    private IEnumerator PlayerState()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            Vector3 startTouchPos = GetScreenPosition();
            isClick = true;

            clickCheckCoroutine = StartCoroutine(CheckClick());

            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || isClick == false);
            Vector3 endTouchPos = GetScreenPosition();
            if (clickCheckCoroutine != null) StopCoroutine(clickCheckCoroutine);

            Vector3 valuePos = endTouchPos - startTouchPos;

            if (isClick)
            {
                if (100 <= valuePos.x)
                {
                    Debug.Log("RIGHT");
                }
                else if (valuePos.x <= -100)
                {
                    Debug.Log("LEFT");
                }
                else
                {
                    Debug.Log("CLICK");
                    Jump();
                }
                isClick = false;
            }
            else
            {
                Jump();
            }
        }
    }


    Vector3 GetScreenPosition()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = camera.farClipPlane;
        return pos;
    }
    bool CheckGround()
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
