using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsProp : MonoBehaviour
{

    private Rigidbody rb;
    private Transform hands;
    private bool held;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (held)
        {
            transform.position = Vector3.Lerp(transform.position, hands.position, 0.1f);
        }
    }

    public void Pickup(Transform hands)
    {
        this.hands = hands;
        rb.isKinematic = true;
        held = true;
    }

    public void PutDown()
    {
        this.hands = null;
        rb.isKinematic = false;
        held = false;
    }
}
