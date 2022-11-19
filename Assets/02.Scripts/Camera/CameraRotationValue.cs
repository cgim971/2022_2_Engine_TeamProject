using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationValue : MonoBehaviour
{
    private bool _useFlag = false;

    [SerializeField] private bool _isXValue = false;
    [SerializeField] private bool _isYValue = false;
    [SerializeField] private bool _isZValue = false;

    [SerializeField] private Vector3 _valueRotation = Vector3.zero;

    private CameraController _cameraController = null;

    private void Awake()
    {
        _cameraController = Camera.main.GetComponent<CameraController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_useFlag)
        {
            _useFlag = true;

            if (_isXValue) _cameraController.XROTATIONVALUE = _valueRotation.x;
            if (_isYValue) _cameraController.YROTATIONVALUE = _valueRotation.y;
            if (_isZValue) _cameraController.ZROTATIONVALUE = _valueRotation.z;
        }
    }
}
