using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    public static PlayerSettings _instance;

    public static PlayerSettings Instance
    {
        get
        {
            return _instance;
        }


    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [Header("M&K Settings")]
    public float mouseXSens = 1f;
    public float mouseYSens = 1f;

    [Header("Controller Settings")]
    public float controllerXSens = 1f;
    public float controllerYSens = 1f;

    [Header("Both Settings")]
    private bool invertLook = false;


    //M&K settings.
    public float GetMouseXSens()
    {
        return mouseXSens;
    }

    public void SetMouseXSens(float mouseX)
    {
        mouseXSens = mouseX;
    }

    public float GetMouseYSens()
    {
        return mouseYSens;
    }

    public void SetMouseYSens(float mouseY)
    {
        mouseYSens = mouseY;
    }


    //Controller Settings
    public float GetControllerXSens()
    {
        return controllerXSens;
    }

    public void SetControllerXSens(float contrX)
    {
        controllerXSens = contrX;
    }

    public float GetControllerYSens()
    {
        return controllerYSens;
    }

    public void SetControllerYSens(float contrY)
    {
        controllerYSens = contrY;
    }
}
