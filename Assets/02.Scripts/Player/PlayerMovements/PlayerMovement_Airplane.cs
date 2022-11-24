using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Airplane : PlayerMovement_Base
{
    private Vector3 _currentDir = Vector3.zero;

    public override void UseInit()
    {
        _customGravity.ISGRAVITY = true;

        StartCoroutine(InputTouch());
    }

    public override bool CheckGround() => true;

    public override void Jumping() { }

    private IEnumerator InputTouch()
    {
        while (true)
        {
            _customGravity.ISGRAVITY = true;
            _currentDir = _dir;

            yield return new WaitUntil(() => Input.GetMouseButton(0));
            _rigidbody.velocity = Vector3.zero;

            _customGravity.ISGRAVITY = false;
            _currentDir.x += (_customGravity.GRAVITY.x > 0 ? -1 : _customGravity.GRAVITY.x < 0 ? 1 : 0);
            _currentDir.y += (_customGravity.GRAVITY.y > 0 ? -1 : _customGravity.GRAVITY.y < 0 ? 1 : 0);
            _currentDir.z += (_customGravity.GRAVITY.z > 0 ? -1 : _customGravity.GRAVITY.z < 0 ? 1 : 0);

            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            _rigidbody.velocity = Vector3.zero;
        }
    }

    public override void Move()
    {
        _rigidbody.MovePosition(this.gameObject.transform.position + _currentDir * _speed * Time.deltaTime);
    }
}
