using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsProp : MonoBehaviour
{

    private Rigidbody rb;
    private Transform hands;
    private bool held;

    public float heldDrag;
    private float defaultDrag;
    public float toHandsStrength;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        defaultDrag = rb.drag;
    }

    // Update is called once per frame
    void Update()
    {
        if (held)
        {
            //transform.position = Vector3.Lerp(transform.position, hands.position, 0.1f);
            rb.AddForce((hands.position - transform.position) * Time.deltaTime * toHandsStrength);
        }
    }

    public void Pickup(Transform hands)
    {
        this.hands = hands;
        rb.useGravity = false;
        held = true;
        rb.drag = heldDrag;
    }

    public void PutDown()
    {
        this.hands = null;
        rb.useGravity = true;
        held = false;
        rb.drag = defaultDrag;
    }
}
