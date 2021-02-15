using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private const float DefaultDamage = 10;    

    private const int NPCLayer = 8;
    private const float MaxSpeed = 10f;

    private Rigidbody _rb;
    private List<GameObject> _npcList = new List<GameObject>();
    private float _health = 200;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != NPCLayer) return;

        _npcList.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer != NPCLayer) return;

        _npcList.Remove(collision.gameObject);
    }

    private void TryAttack()
    {
        //needs optimize to not use linq
        var list = _npcList.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToList();

        if(list.Count == 0) return;

        list[0].GetComponent<CombatBase>().TakeDamage(DefaultDamage, this);
    }

    public void NPCDestroyed(GameObject gameObject)
    {
        _npcList.Remove(gameObject);
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
            TryAttack();
        }
    }
}
