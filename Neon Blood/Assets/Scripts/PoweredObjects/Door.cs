using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoweredObject))]
[RequireComponent(typeof(BoxCollider))]
public class Door : MonoBehaviour
{
    private PoweredObject power;
    private BoxCollider detection;
    public Animator animContr;
    public bool open = false;

    public float blockers;
    // Start is called before the first frame update
    void Start()
    {
        power = GetComponent<PoweredObject>();
        detection = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (power.GetPowered())
        {
            animContr.SetBool("Open", true);
        } else if(blockers == 0)
        {
            animContr.SetBool("Open", false);
        }

        if(blockers < 0)
        {
            Debug.LogError("Less than 0 blockers detected");
            Debug.Break();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        blockers++;
    }

    private void OnTriggerExit(Collider other)
    {
        blockers--;
    }
}
