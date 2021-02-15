using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float MaxSpeed = 10f;
    private Rigidbody _rb;
    private PlayerCombat _playerCombat;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerCombat = GetComponent<PlayerCombat>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector3.left * MaxSpeed);
        }

        if(Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector3.right * MaxSpeed);
        }

        if(Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(Vector3.forward * MaxSpeed);
        }

        if(Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(Vector3.back * MaxSpeed);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _playerCombat.TryAttack();
        }
    }
}
