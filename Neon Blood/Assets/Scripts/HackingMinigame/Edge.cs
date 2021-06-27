using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Edge : MonoBehaviour
{
    public Board board;
    public Node[] nodes;
    private LineRenderer lr;
    private bool travelled;
    public Color baseCol;
    public Color usedCol;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        if (nodes.Length > 2)
        {
            Debug.LogError("Edge connects more than 2 nodes!");
            Debug.Break();
        }
        lr.startColor = baseCol;
        lr.endColor = baseCol;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, nodes[0].transform.position);
        lr.SetPosition(1, nodes[1].transform.position);
    }

    public void Travel()
    {
        travelled = true;
        lr.startColor = usedCol;
        lr.endColor = usedCol;
    }

    void Activate()
    {
        lr.SetPosition(0, nodes[0].transform.position);
        lr.SetPosition(1, nodes[1].transform.position);
    }

    public bool JoinedTo(Node node)
    {
        return (nodes[0] == node || nodes[1] == node);
    }

    public Node NotThisNode(Node node)
    {
        if(nodes[0] == node)
        {
            return nodes[1];
        } else if(nodes[1] == node)
        {
            return nodes[0];
        } else
        {
            Debug.LogError("I couldn't find that node");
            Debug.Break();
            return null;
        }
    }

    public bool HasTravelled()
    {
        return travelled;
    }
}
