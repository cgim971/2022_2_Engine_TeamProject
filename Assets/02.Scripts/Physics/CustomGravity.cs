using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    [SerializeField] private float gravityScale = 1.0f;
    private static float globalGravity = -9.81f;


    private Vector3 gravity = Vector3.down;
    public Vector3 GRAVITY => gravity;

    Rigidbody m_rb;

    void OnEnable()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
    }

    public void SetGravity()
    {
        gravity *= -1;

        GetComponent<Player_BaseMovement>().Rotation(false, true);

        gravityScale *= -1f;
        //GetComponent<ParticleSystem>().Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetGravity();
        }
    }
}