using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region VALUE property
    private Vector3 _valuePos = Vector3.zero;

    private float _xValue = 0f;
    public float XVALUE
    {
        get => _xValue;
        set
        {
            _xValue = value;
            _valuePos.x = _xValue;
        }
    }

    private float _yValue = 0f;
    public float YVALUE
    {
        get => _yValue;
        set
        {
            _yValue = value;
            _valuePos.y = _yValue;
        }
    }

    private float _zValue = 0f;
    public float ZVALUE
    {
        get => _zValue;
        set
        {
            _zValue = value;
            _valuePos.z = _zValue;
        }
    }
    #endregion

    private void LateUpdate() => CameraMove();
    private void CameraMove()
    {
        transform.position = _valuePos; //Vector3.Lerp(transform.position,_valuePos, 0.04f) ;
    }
}
