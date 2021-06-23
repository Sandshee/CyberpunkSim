using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public Transform ladderBottom;
    public Transform ladderTop;
    public float height;

    public int steps;

    // Start is called before the first frame update
    void Start()
    {
        height = Vector3.Magnitude(ladderTop.position - ladderBottom.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Get the public position;
    public Vector3 Connect(Vector3 characterPos)
    {
        Vector3 BC = characterPos - ladderBottom.position;
        Vector3 BT =  ladderTop.position - ladderBottom.position;

        float distanceUp = Vector3.Dot(BC, BT)/Vector3.Magnitude(BT);
        float t = distanceUp / BT.magnitude;

        return Vector3.Lerp(ladderBottom.position, ladderTop.position, t);
    }
}
