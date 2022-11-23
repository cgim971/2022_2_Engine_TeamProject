using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    #region VALUE property
    #region POS VALUE
    private Vector3 _posValue = Vector3.zero;

    private float _xPosValue = 0f;
    public float XPOSVALUE
    {
        get => _xPosValue;
        set
        {
            _xPosValue = value;
            _posValue.x = _xPosValue;
        }
    }

    private float _yPosValue = 0f;
    public float YPOSVALUE
    {
        get => _yPosValue;
        set
        {
            _yPosValue = value;
            _posValue.y = _yPosValue;
        }
    }

    private float _zPosValue = 0f;
    public float ZPOSVALUE
    {
        get => _zPosValue;
        set
        {
            _zPosValue = value;
            _posValue.z = _zPosValue;
        }
    }
    #endregion
    #region CHECK VALUE
    private bool _isXPosValue = false;
    public bool ISXPOSVALUE { get => _isXPosValue; set => _isXPosValue = value; }
    private bool _isYPosValue = false;
    public bool ISYPOSVALUE { get => _isYPosValue; set => _isYPosValue = value; }
    private bool _isZPosValue = false;
    public bool ISZPOSVALUE { get => _isZPosValue; set => _isZPosValue = value; }
    #endregion
    #region ROTATION VALUE
    private Vector3 _rotationValue = Vector3.zero;
    private float _xRotationValue = 0f;
    public float XROTATIONVALUE
    {
        get => _xRotationValue;
        set
        {
            _xRotationValue = value;
            _rotationValue.x = _xRotationValue;
        }
    }
    private float _yRotationValue = 0f;
    public float YROTATIONVALUE
    {
        get => _yRotationValue;
        set
        {
            _yRotationValue = value;
            _rotationValue.y = _yRotationValue;
        }
    }
    private float _zRotationValue = 0f;
    public float ZROTATIONVALUE
    {
        get => _zRotationValue;
        set
        {
            _zRotationValue = value;
            _rotationValue.z = _zRotationValue;
        }
    }
    #endregion
    #endregion

    [SerializeField] private float _time = 0.05f;

    private void LateUpdate() => CameraMove();
    private void CameraMove()
    {
        transform.position = GetLerpValue();
        transform.DORotate(_rotationValue, 0.1f);
    }

    Vector3 GetLerpValue()
    {
        return new Vector3(GetLerpValueX(), GetLerpValueY(), GetLerpValueZ());
    }

    float GetLerpValueX()
    {
        if (_isXPosValue) return _posValue.x;
        return Mathf.Lerp(transform.position.x, _posValue.x, _time);
    }
    float GetLerpValueY()
    {
        if (_isYPosValue) return _posValue.y;
        return Mathf.Lerp(transform.position.y, _posValue.y, _time);
    }
    float GetLerpValueZ()
    {
        if (_isZPosValue) return _posValue.z;
        return Mathf.Lerp(transform.position.z, _posValue.z, _time);
    }
}
