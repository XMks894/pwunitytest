using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private NPCCombat _npcCombat;

    public Transform PlayerTransform;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _npcCombat = GetComponent<NPCCombat>();
    }

    private void Start()
    {
        Invoke(nameof(TryAttack), 0.5f);
    }

    private void Update()
    {
        if(PlayerTransform == null) return;

        _navMeshAgent.SetDestination(PlayerTransform.position);
    }

    private void TryAttack()
    {
        _npcCombat.TryAttack();
    }
}
