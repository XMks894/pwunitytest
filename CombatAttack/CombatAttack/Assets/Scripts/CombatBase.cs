using UnityEngine;

public class CombatBase : MonoBehaviour
{
    public float Health = 100;

    public void TakeDamage(float damage, PlayerCombat playerCombat)
    {
        Health -= damage;

        Debug.Log($"{gameObject.name} => Health: {Health}");

        if(Health <= 0)
        {
            playerCombat.NPCDestroyed(gameObject);
        }
    }
}
