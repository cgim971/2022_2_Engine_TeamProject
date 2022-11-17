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
        //camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(transform.position.x - dir.x * 10, 3, transform.position.z - dir.z * 10), 1f);
        //camera.transform.LookAt(transform.position);
        // 카메라가 부드럽게 회전하기

        //camera.transform.position = transform.position + new Vector3(transform.position.x - dir.x * 10, 3, transform.position.z - dir.z * 10);
        //camera.transform.LookAt(transform.position);
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
                //if (100 <= valuePos.x)
                //    Rotation(false);
                //else if (valuePos.x <= -100)
                //    Rotation(true);
                //else
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
            Vector3 jumpPower = gravity.GRAVITY * -1 * jumpHeight;
            rb.AddForce(jumpPower, ForceMode.VelocityChange);
        }
    }
    public override void Rotation(bool isleft = false, bool isgravity = false)
    {
        if (isgravity)
        {
            rot.z += 180;
            transform.DORotate(rot, 1f).SetEase(Ease.Linear);
            return;
        }
        if (isleft)
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
