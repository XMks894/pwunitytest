﻿using UnityEngine;
using System.Linq;

public class PlayerCombat : CombatBase
{
    private const int NPCLayer = 8;

    protected override void OnCollisionEnter(Collision collision)
    {
        if(!IsNPC(collision.gameObject)) return;

        List.Add(collision.gameObject);
    }

    protected override void OnCollisionExit(Collision collision)
    {
        if(!IsNPC(collision.gameObject)) return;

        List.Remove(collision.gameObject);
    }

    private bool IsNPC(GameObject obj)
    {
        return obj.layer == NPCLayer;
    }

    public override void TryAttack()
    {
        //needs optimize to not use linq
        var list = List.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToList();

        if(list.Count == 0) return;

        TakeDamage(Damage, list[0]);
    }

    protected override void TakeDamage(float damage, GameObject obj)
    {
        var combat = obj.GetComponent<CombatBase>();

        if(combat == null) return;

        combat.Health -= damage;

        Debug.Log($"{obj.name} => Health: {combat.Health}");

        if(combat.Health <= 0) DestroyCombat(obj);
    }
}
