using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement_Base : MonoBehaviour
{
    #region Caching
    protected Rigidbody _rigidbody = null;
    protected CustomGravity _customGravity = null;
    protected CameraController _cameraController = null;
    #endregion

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
    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _customGravity = GetComponent<CustomGravity>();
        _cameraController = Camera.main.GetComponent<CameraController>();

        _groundLayer = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        Move();
        CameraMove();
    }

    public void TurnObject() => _dir *= -1;
    public void TurnObject(Vector3 dir) => _dir = dir;

    public abstract void Move();
    public abstract void Jumping();
    public abstract bool CheckGround();

    public void CameraMove() => _cameraController.ZPOSVALUE = transform.position.z;
}
