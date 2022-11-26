using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Robot : PlayerMovement_Base
{
    [SerializeField] private int _jump = 2;
    public override void UseInit()
    {
        _customGravity.ISGRAVITY = true;

        StartCoroutine(InputTouch());
    }

    private IEnumerator InputTouch()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || CheckGround());

            Jump();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public override void Move() => _rigidbody.MovePosition(this.gameObject.transform.position + _dir * _speed * Time.deltaTime);

    public override bool CheckGround()
    {
        if (Physics.Raycast(transform.position - (_customGravity.GRAVITY * -1 * 0.2f), _customGravity.GRAVITY, 0.4f, _groundLayer))
        {
            _jumpExtraCount = 0;
            _jump = 1;
            return true;
        }
        return false;
    }

    public override void Jumping()
    {
        _rigidbody.velocity = Vector3.zero;

        Vector3 jumpPower = _customGravity.GRAVITY * -1 * _jumpPower;
        _rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
    }

    public void Jump()
    {
        if (CheckGround() || _jumpExtraCount > 0 || _jump > 0)
        {
            Debug.Log("A");
            if (_jumpExtraCount > 0) _jumpExtraCount -= 1;
            if (!CheckGround()) _jump -= 1;
            Jumping();
        }
    }
}

