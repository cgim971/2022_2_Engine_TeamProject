using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomGravity))]
public class PlayerController : MonoBehaviour
{
    #region Caching
    private Rigidbody _rigidbody = null;
    public Rigidbody RIGIDBODY { get => _rigidbody; set => _rigidbody = value; }
    private CustomGravity _customGravity = null;
    public CustomGravity CUSTOMGRAVITY { get => _customGravity; set => _customGravity = value; }
    private CameraController _cameraController = null;
    public CameraController CAMERACONTROLLER { get => _cameraController; set => _cameraController = value; }
    #endregion

    private void Awake() => Init();
    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _customGravity = GetComponent<CustomGravity>();
        _cameraController = Camera.main.GetComponent<CameraController>();
    }
}
