using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Board board;
    public Edge[] edges;
    public bool active;
    InputManager im;

    public Material baseMat;
    public Material optionalMat;
    public Material selectedMat;

    MeshRenderer mr;

    // Start is called before the first frame update
    void Awake()
    {
        im = InputManager.Instance;
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Avail()
    {
        mr.material = optionalMat;
    }

    public void Unavail()
    {
        mr.material = baseMat;
    }

    public void Activate()
    {
        active = true;
        mr.material = selectedMat;
    }

    public void DeActivate()
    {
        active = false;
        mr.material = baseMat;
    }

    public Edge FindEdge(Node node)
    {
        foreach(Edge e in edges)
        {
            if(e.JoinedTo(node))
            {
                return e;
            }
        }

        Debug.LogError("I couldn't find that edge");
        return null;
    }

    public List<Node> FindPossibilities()
    {
        List<Node> returnNodes = new List<Node>();
        foreach(Edge e in edges)
        {
            if (!e.HasTravelled())
            {
                Node tempNode = e.NotThisNode(this);
                tempNode.Avail();
                returnNodes.Add(tempNode);
            }
        }

        return returnNodes;
    }

    public void OnMouseOver()
    {
        if (im.PlayerShotThisFrame())
        {
            //The player clicked.
            board.PickNode(this);
            Debug.Log("MouseClick");
        }
        Debug.Log("MouseOver");
    }

    public void ButtonDepress()
    {
        board.PickNode(this);
        Debug.Log("ButtonPress");
    }
}
