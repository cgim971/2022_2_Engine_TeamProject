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
            _isXPosValue = true;

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
            _isYPosValue = true;

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
            _isZPosValue = true;

            _zPosValue = value;
            _posValue.z = _zPosValue;
        }
    }
    #endregion
    #region DETAIL POS VALUE
    private bool _isDetailPosValue = false;
    public bool ISDETAILPOSVALUE { get => _isDetailPosValue; set => _isDetailPosValue = value; }

    private Vector3 _detailPosValue = Vector3.zero;
    public Vector3 DETAILPOSVALUE
    {
        get => _detailPosValue; set
        {
            _isDetailPosValue = true;
            _detailPosValue = value;
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
        float transformPositionX = transform.position.x;
        float posValueX = _posValue.x;

        if (_isDetailPosValue)
        {
            transformPositionX += _detailPosValue.x;
            posValueX += _detailPosValue.x;
        }
        if (_isXPosValue) return posValueX;

        return Mathf.Lerp(transformPositionX, posValueX, _time);
    }
    float GetLerpValueY()
    {
        float transformPositionY = transform.position.y;
        float posValueY = _posValue.y;

        if (_isDetailPosValue)
        {
            transformPositionY += _detailPosValue.y;
            posValueY += _detailPosValue.y;
        }
        if (_isYPosValue) return posValueY;

        return Mathf.Lerp(transformPositionY, posValueY, _time);
    }
    float GetLerpValueZ()
    {
        float transformPositionZ = transform.position.z;
        float posValueZ = _posValue.z;

        if (_isDetailPosValue)
        {
            transformPositionZ += _detailPosValue.z;
            posValueZ += _detailPosValue.z;
        }
        if (_isZPosValue) return posValueZ;

        return Mathf.Lerp(transformPositionZ, posValueZ, _time);
    }
}
