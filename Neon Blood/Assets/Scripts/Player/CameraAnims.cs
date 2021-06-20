using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnims : MonoBehaviour
{
    //Effects:
    [Header("Generic Settings")]
    InputManager im;
    public PlayerController player;
    public Vector3 initialPos;

    //Zoom
    [Header("Zoom Settings")]
    public float fieldOfViewMod = 0.5f;
    public float zoomAnimationTime;
    private float zoomTime;
    private float initialFOV;
    private bool zooming;
    //Shake
    [Header("Shake Settings")]
    public float shakeMagnitude;
    public float shakeDecay;
    //Sway
    [Header("Sway Settings")]
    public float swayMagnitude;
    public float swayTime;
    //Land
    [Header("Landing Settings")]
    public float landingMagnitude;
    public float landingDecay;
    //Jump
    //[Header("Jump Settings")]
    //public float jump

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        initialFOV = cam.fieldOfView;
        im = InputManager.Instance;
        initialPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
        CameraSway();
    }

    /* The zoom functionality, usable without a weapon, allowing players to focus in on something.
     * 
     * Zoom is achieved through adjusting the FoV, by a percentage to respect FOV choices.
     */

    void CameraZoom()
    {
        //Are they still zooming?
        if (im.PlayerZoomedThisFrame())
        {
            zooming = true;
        } else if (im.PlayerStopZoomedThisFrame())
        {
            zooming = false;
        }

        //Add the new values.
        if(zoomTime <= zoomAnimationTime && zoomTime >= 0)
        {
            if (zooming)
            {
                zoomTime += Time.deltaTime;
            } else
            {
                zoomTime -= Time.deltaTime;
            }
        }

        //Calculate T.
        float t = zoomTime / zoomAnimationTime;

        // Give it bounds.
        t = Mathf.Clamp(t, 0, 1);

        zoomTime = Mathf.Clamp(zoomTime, 0, zoomAnimationTime);

        float fov = Mathf.Lerp(initialFOV, initialFOV * fieldOfViewMod, t);

        cam.fieldOfView = fov;
    }


    /* The camera bob functionality. Vertical bob is the focus.
     * 
     * Horizontal sway should be achievable, but not desirable.
     */
    void CameraSway()
    {
        float t = player.getSpeed();
        //This currently works, but it doesn't play nicely with controllers. Fix pls.
        //TODO: Fix.
        transform.localPosition = initialPos + Vector3.up * swayMagnitude * Mathf.Sin(t * Time.time * swayTime);
    }
}
