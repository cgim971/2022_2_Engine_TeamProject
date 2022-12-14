using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    private Rigidbody _rigidbody = null;

    [SerializeField] private float _gravityScale = 4.0f;
    private static float _globalGravity = -9.81f;

    private bool _isGravity = false;
    public bool ISGRAVITY { get => _isGravity; set => _isGravity = value; }

    private Vector3 _gravity = Vector3.down;
    public Vector3 GRAVITY => _gravity;

    private void Awake() => Init();
    void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    void FixedUpdate() => Gravity();

    private void Gravity()
    {
        if (!_isGravity) return;

        Vector3 gravity = _globalGravity * _gravityScale * (_gravity * -1);
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    public void ReverseGravity()
    {
        _gravity *= -1;
        //GetComponent<ParticleSystem>().Play();
    }
    public void SetGravity(Vector3 gravity)
    {
        _gravity = gravity;
        _rigidbody.velocity = Vector3.zero;


        //GetComponent<ParticleSystem>().Play();
    }
}