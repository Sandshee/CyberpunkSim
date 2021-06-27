using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3D : Interactible
{
    public PoweredObject destination;
    public float duration = 2f;
    public bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        Debug.Log("Boop!");
        if (!locked)
        {
            destination.Power(duration);
            //Play unlocked animation.
        } else
        {
            //Play locked animation.
        }
    }
}
