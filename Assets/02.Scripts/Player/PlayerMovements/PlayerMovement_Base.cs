using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement_Base : MonoBehaviour
{
    protected PlayerController _playerController;
    protected Rigidbody _rigidbody;
    protected CustomGravity _customGravity = null;
    protected CameraController _cameraController = null;

    #region MoveProperty
    protected Vector3 _dir = Vector3.forward;

    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected float _jumpPower = 18f;

    protected int _jumpExtraCount = 0;
    public int JUMPEXTRACOUNT
    {
        get => _jumpExtraCount;
        set => _jumpExtraCount = value;
    }

    protected LayerMask _groundLayer;
    #endregion

    private void Awake() => Init();

    void Init()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _rigidbody = _playerController.RIGIDBODY;
        _customGravity = _playerController.CUSTOMGRAVITY;
        _cameraController = _playerController.CAMERACONTROLLER;

        _groundLayer = LayerMask.GetMask("Ground");
    }

    public abstract void UseInit();

    public virtual void FixedUpdate()
    {
        Move();
        CameraMove();
    }
    public void TurnObject() => _dir *= -1;
    public void TurnObject(Vector3 dir) => _dir = dir;

    public abstract void Move();
    public abstract void Jumping();
    public abstract bool CheckGround();
    public void CameraMove()
    {
        if (_dir.x != 0)
        {
            _cameraController.ISXPOSVALUE = true;
            _cameraController.XPOSVALUE = transform.position.x;
        }
        else
        {
            _cameraController.ISXPOSVALUE = false;
        }

        if (_dir.y != 0)
        {
            _cameraController.ISYPOSVALUE = true;
            _cameraController.YPOSVALUE = transform.position.y;
        }
        else
        {
            _cameraController.ISYPOSVALUE = false;
        }

        if (_dir.z != 0)
        {
            _cameraController.ISZPOSVALUE = true;
            _cameraController.ZPOSVALUE = transform.position.z;
        }
        else
        {
            _cameraController.ISZPOSVALUE = false;
        }
    }
}
