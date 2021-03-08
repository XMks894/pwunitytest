using Pathfinding;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private AIDestinationSetter _aIDestinationSetter;

    public AIManager AIManagerInstance;

    private void Awake()
    {
        _aIDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(TryToFindPlayerArea), 2f, 2f);
    }

    private void TryToFindPlayerArea()
    {
        var area = AIManagerInstance.TryToFindPlayerArea();

        if(area == null)
        {
            _aIDestinationSetter.target = null;
        }
        else
        {
            //TODO set patrol for a few waypoints
            //add fieldofview for NPC
            _aIDestinationSetter.target = AIManagerInstance.GetPlayer();
        }
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }
}
