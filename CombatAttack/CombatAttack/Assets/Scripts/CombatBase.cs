using System.Collections.Generic;
using UnityEngine;

public abstract class CombatBase : MonoBehaviour
{
    public float Health = 100;
    public float Damage = 20;

    protected readonly List<GameObject> List = new List<GameObject>();

    protected abstract void TakeDamage(float damage, GameObject obj);

    protected void DestroyCombat(GameObject obj)
    {
        List.Remove(obj);
        Destroy(obj);
    }

    protected abstract void OnCollisionEnter(Collision collision);

    protected abstract void OnCollisionExit(Collision collision);

    public abstract void TryAttack();
}
