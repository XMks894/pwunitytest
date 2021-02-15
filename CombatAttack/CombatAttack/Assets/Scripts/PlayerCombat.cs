using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerCombat : MonoBehaviour
{
    private const float DefaultDamage = 10;

    private const int NPCLayer = 8;

    private List<GameObject> _npcList = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != NPCLayer) return;

        _npcList.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer != NPCLayer) return;

        _npcList.Remove(collision.gameObject);
    }

    public void TryAttack()
    {
        //needs optimize to not use linq
        var list = _npcList.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToList();

        if(list.Count == 0) return;

        list[0].GetComponent<CombatBase>().TakeDamage(DefaultDamage, this);
    }

    public void NPCDestroyed(GameObject gameObject)
    {
        _npcList.Remove(gameObject);
        Destroy(gameObject);
    }
}
