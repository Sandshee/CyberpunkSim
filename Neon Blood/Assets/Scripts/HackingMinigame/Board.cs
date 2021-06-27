using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Node[] nodes;
    public Button[] buttons;
    public Node startNode;
    public Node activeNode;
    public List<Node> optionalNodes;
    public float radius;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        startNode.Activate();
        optionalNodes = new List<Node>();
        //Positioning the Hexagon nodes:
        float increase = Mathf.Deg2Rad * 60;

        Debug.Log("Nodes: " + nodes.Length);
        for (int i = 0; i < 6; i++)
        {
            nodes[i].transform.localPosition = new Vector3(radius * Mathf.Cos(increase * i), 0, radius * Mathf.Sin(increase * i));
            buttons[i].transform.localPosition = new Vector2(radius * 80 * Mathf.Cos(increase * i), radius * 80 * Mathf.Sin(increase * i));
        }

        activeNode = startNode;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            started = true;
            ActivateAvailableNodes();
        }
    }

    public bool PickNode(Node node)
    {
        if (optionalNodes.Contains(node))
        {
            activeNode.FindEdge(node).Travel();
            activeNode = node;
            ActivateAvailableNodes();
            return true;
        } else
        {
            Debug.LogError("That node is not available");
            return false;
        }
    }

    void ActivateAvailableNodes()
    {
        foreach(Node n in nodes)
        {
            if(n != activeNode)
            {
                n.DeActivate();
            }
        }

        optionalNodes = activeNode.FindPossibilities();
    }
}
