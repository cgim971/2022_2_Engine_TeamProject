using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationObject : Object_Base
{
    [SerializeField] private bool _isXValue = false;
    [SerializeField] private bool _isYValue = false;
    [SerializeField] private bool _isZValue = false;

    [SerializeField] private Vector3 _valueRotation = Vector3.zero;

    private CameraController _cameraController = null;

    private void Awake()
    {
        _cameraController = Camera.main.GetComponent<CameraController>();
    }

    public override void EffectStart(GameObject obj)
    {
        if (_isXValue) _cameraController.XROTATIONVALUE = _valueRotation.x;
        if (_isYValue) _cameraController.YROTATIONVALUE = _valueRotation.y;
        if (_isZValue) _cameraController.ZROTATIONVALUE = _valueRotation.z;
    }
    public override void EffectEnd(GameObject obj)  {  }
}
