using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxTrigger : MonoBehaviour
{
    private int intersectCounter;
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<BoxCollider>().isTrigger)
        {
            Debug.LogError("This collider was not set to a trigger, doing it automatically.");
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        intersectCounter++;
    }

    private void OnTriggerExit(Collider other)
    {
        intersectCounter--;
        if(intersectCounter < 0)
        {
            Debug.LogError("This " + gameObject.name + " is intersecting a negative number of objects.");
        }
    }

    public bool IsTriggered()
    {
        return intersectCounter > 0;
    }
}
