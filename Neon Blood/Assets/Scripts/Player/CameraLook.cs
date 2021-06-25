using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    public Transform playerBody;
    public Transform lockLocation;
    public Transform cameraParent;
    private InputManager im;
    private PlayerSettings ps;

    float xRotation = 0f;

    public float normaliseYSens = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        im = InputManager.Instance;
        ps = PlayerSettings.Instance;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVec;
        if (im.GetMouseLook() == Vector2.zero) {
            inputVec = im.GetControllerLook();
            inputVec = new Vector2(inputVec.x * ps.GetControllerXSens(), inputVec.y * ps.GetControllerYSens() * normaliseYSens);
        } else
        {
            inputVec = im.GetMouseLook();
            inputVec = new Vector2(inputVec.x * ps.GetMouseXSens(), inputVec.y * ps.GetMouseYSens() * normaliseYSens);
        }

        xRotation -= inputVec.y;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * inputVec.x * ps.GetMouseXSens());

        cameraParent.transform.position = Vector3.Lerp(cameraParent.transform.position, lockLocation.position, 0.2f);
        cameraParent.transform.rotation = lockLocation.rotation;
    }
}
