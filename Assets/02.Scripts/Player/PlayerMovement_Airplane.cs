using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Airplane : PlayerMovement_Base
{

    public override void UseInit()
    {
        _customGravity.ISGRAVITY = true;
    }

    public override bool CheckGround() => true;

    public override void Jumping() { }

    public override void Move()
    {
        _rigidbody.MovePosition(this.gameObject.transform.position + _dir * _speed * Time.deltaTime);
    }

}
