using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosObject : Object_Base
{
    [SerializeField] private bool _isXValue = false;
    [SerializeField] private bool _isYValue = false;
    [SerializeField] private bool _isZValue = false;

    [SerializeField] private Vector3 _valuePos = Vector3.zero;


    private CameraController _cameraController = null;

    private void Awake()
    {
        _cameraController = Camera.main.GetComponent<CameraController>();
    }
    public override void EffectStart(GameObject obj)
    {
        if (_isXValue) _cameraController.XPOSVALUE = _valuePos.x;
        if (_isYValue) _cameraController.YPOSVALUE = _valuePos.y;
        if (_isZValue) _cameraController.ZPOSVALUE = _valuePos.z;
    }
    public override void EffectEnd(GameObject obj) { }
}
