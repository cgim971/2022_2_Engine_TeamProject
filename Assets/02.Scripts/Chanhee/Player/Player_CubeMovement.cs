using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player_CubeMovement : Player_BaseMovement
{

    Coroutine clickCheckCoroutine;

    public void Start()
    {
        base.Start();
        StartCoroutine(PlayerMoveState());
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override IEnumerator PlayerMoveState()
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
                    Rotation(false);
                else if (valuePos.x <= -100)
                    Rotation(true);
                else
                    Jump();

                isClick = false;
            }
            else
            {
                Jump();
            }
        }
    }
    private IEnumerator CheckClick()
    {
        yield return new WaitForSeconds(0.3f);
        if (isClick == true) isClick = false;
    }


    #region Move
    void Move()
    {
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
    public void Rotation(bool isLeft = false)
    {
        if (isLeft)
        {
            rot.y -= 90;

            if (dir.z == 0)
            {
                dir.z = dir.x == 1 ? 1 : -1;
                dir.x = 0;
            }
            else
            {
                dir.x = dir.z == 1 ? -1 : 1;
                dir.z = 0;
            }
        }
        else
        {
            rot.y += 90;

            if (dir.z == 0)
            {
                dir.z = dir.x == 1 ? -1 : 1;
                dir.x = 0;
            }
            else
            {
                dir.x = dir.z == 1 ? 1 : -1;
                dir.z = 0;
            }
        }
        transform.DORotate(rot, 0.5f).SetEase(Ease.Linear);
    }
    #endregion
}
