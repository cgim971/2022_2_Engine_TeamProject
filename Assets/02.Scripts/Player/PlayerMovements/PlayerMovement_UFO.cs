using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_UFO : PlayerMovement_Base
{
    public override void UseInit()
    {
        _customGravity.ISGRAVITY = true;
    }

    public override bool CheckGround() => true;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Input.GetMouseButton(0))
        {
            Jumping();
        }
    }

    public override void Jumping()
    {
        _rigidbody.velocity = Vector3.zero;

        Vector3 jumpPower = _customGravity.GRAVITY * -1 * _jumpPower;
        _rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);

    }

    public override void Move() => _rigidbody.MovePosition(this.gameObject.transform.position + _dir * _speed * Time.deltaTime);
}
