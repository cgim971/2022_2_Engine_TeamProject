using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CustomGravity))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody = null;
    private CustomGravity _customGravity = null;
    private Camera _camera = null;

    private LayerMask _groundLayer;

    private Vector3 _dir = Vector3.forward;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpPower = 18f;


    private int _jumpExtraCount = 0;
    public int JUMPEXTRACOUNT
    {
        get => _jumpExtraCount;
        set => _jumpExtraCount = value;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _customGravity = GetComponent<CustomGravity>();
        _camera = FindObjectOfType<Camera>();

        _groundLayer = LayerMask.GetMask("Ground");
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        // ī�޶� ���� �ʿ�
        CameraMove();
    }

    public void CameraMove()
    {
        Vector3 cameraPos = transform.position + new Vector3(15, _customGravity.ISGRAVITY ? -1 : 1 * 5, 0);
        _camera.transform.position = cameraPos;
    }

    public void Move()
    {
        _rigidbody.MovePosition(this.gameObject.transform.position + _dir * _speed * Time.deltaTime);
    }

    public bool CheckGround()
    {
        if (Physics.Raycast(transform.position - (_customGravity.GRAVITY * -1 * 0.2f), _customGravity.GRAVITY, 0.4f, _groundLayer))
        {
            _jumpExtraCount = 0;
            return true;
        }
        return false;
    }

    public void Jump()
    {
        Debug.Log(_jumpExtraCount);
        if (CheckGround() || _jumpExtraCount > 0)
        {
            if (_jumpExtraCount > 0) _jumpExtraCount -= 1;

            _rigidbody.velocity = Vector3.zero;

            Vector3 jumpPower = _customGravity.GRAVITY * -1 * _jumpPower;
            _rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
        }
    }
}
