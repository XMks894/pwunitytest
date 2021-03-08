using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    private GridGraph _gridGraph;

    private readonly Dictionary<int, List<GridNode>> _areaList = new Dictionary<int, List<GridNode>>();

    public Transform PlayerPosition;

    private void Start()
    {
        Initialize();
        InitializeAreas();
    }

    private void Initialize()
    {
        _gridGraph = AstarPath.active.data.gridGraph;
    }

    private void InitializeAreas()
    {
        //GridGraph 10x10
        //nodeSize = 3
        //think to randomize area squares

        _areaList.Add(0, new List<GridNode> { _gridGraph.nodes[98], _gridGraph.nodes[94], _gridGraph.nodes[78], _gridGraph.nodes[74] });
        _areaList.Add(1, new List<GridNode> { _gridGraph.nodes[54], _gridGraph.nodes[50], _gridGraph.nodes[34], _gridGraph.nodes[30] });
        _areaList.Add(2, new List<GridNode> { _gridGraph.nodes[24], _gridGraph.nodes[20], _gridGraph.nodes[4], _gridGraph.nodes[0] });
    }

    public List<GridNode> TryToFindPlayerArea()
    {
        foreach(var area in _areaList)
        {
            Debug.Log($"Player position: {PlayerPosition.position}");

            var p1 = (Vector3)area.Value[1].position;
            var p2 = (Vector3)area.Value[0].position;
            var p3 = (Vector3)area.Value[3].position;
            var p4 = (Vector3)area.Value[2].position;

            Debug.Log($"Area {area.Key}: x<{p1.x},{p2.x}>, z<{p2.z},{p4.z}>");

            if (PlayerPosition.position.x > p1.x
                && PlayerPosition.position.x < p2.x
                && PlayerPosition.position.z < p2.z
                && PlayerPosition.position.z > p4.z)
            {
                return area.Value;
            }
        }

        return null;
    }

    public Transform GetPlayer()
    {
        return PlayerPosition;
    }

    private void OnDrawGizmosSelected()
    {
        if(_areaList.Count == 0) return;

        foreach(var item in _areaList)
        {
            Gizmos.color = GetColorByArea(item.Key);

            Gizmos.DrawLine((Vector3)item.Value[0].position, (Vector3)item.Value[1].position);
            Gizmos.DrawLine((Vector3)item.Value[2].position, (Vector3)item.Value[3].position);
            Gizmos.DrawLine((Vector3)item.Value[0].position, (Vector3)item.Value[2].position);
            Gizmos.DrawLine((Vector3)item.Value[1].position, (Vector3)item.Value[3].position);
        }
    }

    private Color GetColorByArea(int areaNumber)
    {
        var color = Color.green;

        switch(areaNumber)
        {
            case 0:
                color = Color.green;
                break;
            case 1:
                color = Color.blue;
                break;
            case 2:
                color = Color.red;
                break;
        }

        return color;
    }
}
