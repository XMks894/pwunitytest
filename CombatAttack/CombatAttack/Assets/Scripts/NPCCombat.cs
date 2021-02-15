using UnityEngine;

public class NPCCombat : CombatBase
{
    private const string PlayerTag = "Player";

    protected override void OnCollisionEnter(Collision collision)
    {
        if(!IsPlayer(collision.gameObject)) return;

        List.Add(collision.gameObject);
    }

    protected override void OnCollisionExit(Collision collision)
    {
        if(!IsPlayer(collision.gameObject)) return;

        List.Remove(collision.gameObject);
    }

    private bool IsPlayer(GameObject obj)
    {
        return obj.CompareTag(PlayerTag);
    }

    public override void TryAttack()
    {
        //player is always one

        if(List.Count == 0) return;

        TakeDamage(Damage, List[0]);
    }

    protected override void TakeDamage(float damage, GameObject obj)
    {
        var combat = obj.GetComponent<CombatBase>();

        if (combat == null) return;

        combat.Health -= damage;

        Debug.Log($"{obj.name} => Health: {combat.Health}");

        if(combat.Health <= 0) DestroyCombat(obj);
    }
}
