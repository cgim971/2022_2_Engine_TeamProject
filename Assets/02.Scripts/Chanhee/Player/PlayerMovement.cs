using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CustomGravity))]
public class PlayerMovement : MonoBehaviour
{
    #region Caching
    private Rigidbody _rigidbody = null;
    private CustomGravity _customGravity = null;
    private Camera _camera = null;
    #endregion

    #region MoveProperty
    private Vector3 _dir = Vector3.forward;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpPower = 18f;

    private int _jumpExtraCount = 0;
    public int JUMPEXTRACOUNT
    {
        get => _jumpExtraCount;
        set => _jumpExtraCount = value;
    }

    private LayerMask _groundLayer;

    bool _isTouch = false;
    #endregion

    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _customGravity = GetComponent<CustomGravity>();
        _camera = FindObjectOfType<Camera>();

        _groundLayer = LayerMask.GetMask("Ground");
    }

    private void Start() => StartCoroutine(InputTouch());

    private IEnumerator InputTouch()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || CheckGround());

            Jump();
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void FixedUpdate() => Move();
    private void LateUpdate() => CameraMove();

    public void CameraMove()
    {
        // 카메라 수정 필요

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
        if (CheckGround() || _jumpExtraCount > 0)
        {
            if (_jumpExtraCount > 0) _jumpExtraCount -= 1;

            _rigidbody.velocity = Vector3.zero;

            Vector3 jumpPower = _customGravity.GRAVITY * -1 * _jumpPower;
            Debug.Log(jumpPower);
            _rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
        }
    }
}
