using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float MAX_SPEED = 1000f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector3.left * MAX_SPEED * Time.fixedDeltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector3.right * MAX_SPEED * Time.fixedDeltaTime);
        }

        if(Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(Vector3.up * MAX_SPEED * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(Vector3.down * MAX_SPEED * Time.fixedDeltaTime);
        }
    }
}
