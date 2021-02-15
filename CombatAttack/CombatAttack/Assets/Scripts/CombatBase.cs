using UnityEngine;

public class CombatBase : MonoBehaviour
{
    public float Health = 100;

    public void TakeDamage(float damage, PlayerController player)
    {
        Health -= damage;

        Debug.Log($"Health: {Health}");

        if(Health <= 0)
        {
            player.GetComponent<PlayerController>().NPCDestroyed(gameObject);
            Destroy(gameObject);
        }
    }
}
