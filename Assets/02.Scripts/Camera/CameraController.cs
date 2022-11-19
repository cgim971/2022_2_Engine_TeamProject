using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region VALUE property
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

    private void LateUpdate() => CameraMove();
    private void CameraMove()
    {
        transform.position = _posValue; //Vector3.Lerp(transform.position,_valuePos, 0.04f);
        transform.rotation = Quaternion.Euler(_rotationValue);
    }
}
