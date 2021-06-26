using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredObject : MonoBehaviour
{
    private int coroutineCount;
    public bool powered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Power(float duration)
    {
        powered = true;
        StartCoroutine(Hold(duration));

    }

    IEnumerator Hold(float duration)
    {
        coroutineCount++;
        yield return new WaitForSeconds(duration);
        coroutineCount--;

        if(coroutineCount == 0)
        {
            powered = false;
            //Disable power
        }
    }

    public bool GetPowered()
    {
        return powered;
    }
}
