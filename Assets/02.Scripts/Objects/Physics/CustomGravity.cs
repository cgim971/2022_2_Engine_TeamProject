using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    private Rigidbody _rigidbody = null;

    [SerializeField] private float _gravityScale = 1.0f;
    private static float _globalGravity = -9.81f;


    private Vector3 _gravity = Vector3.down;
    public Vector3 GRAVITY => _gravity;




    void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = _globalGravity * _gravityScale * Vector3.up;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    public void SetGravity()
    {
        _gravity *= -1;
        //GetComponent<Player_BaseMovement>().Rotation(false, true);
        _gravityScale *= -1f;
        //GetComponent<ParticleSystem>().Play();
    }
}