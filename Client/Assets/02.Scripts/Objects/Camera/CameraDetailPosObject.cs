using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetailPosObject : Object_Base
{
    [SerializeField] private bool _isDetail = false;
    [SerializeField] private Vector3 _detailPos = Vector3.zero;

    private CameraController _cameraController = null;
    private void Awake()
    {
        _cameraController = Camera.main.GetComponent<CameraController>();
    }

    public override void EffectStart(GameObject obj)
    {
        if (_isDetail == true)
        {
            _cameraController.DETAILPOSVALUE = _detailPos;
        }
        else
        {
            _cameraController.ISDETAILPOSVALUE = false;
        }
    }
    public override void EffectEnd(GameObject obj) { }
}
