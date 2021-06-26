using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnims : MonoBehaviour
{
    //Effects:
    [Header("Generic Settings")]
    public float minY;
    InputManager im;
    public PlayerController player;
    public Vector3 initialPos;
    private Vector3 offsetValues;
    public PlayerAudio pAudio;

    //Zoom
    [Header("Zoom Settings")]
    public float fieldOfViewMod = 0.5f;
    public float zoomAnimationTime;
    private float zoomTime;
    private float initialFOV;
    private bool zooming;

    //Sprint
    [Header("Sprint Settings")]
    public float sprintFieldOfViewMod = 1.2f;
    public float sprintAnimationTime;
    public float sprintTime;
    private bool sprinting;

    //Shake
    [Header("Shake Settings")]
    public float shakeMagnitude;
    public float shakeDecay;
    //Sway
    [Header("Sway Settings")]
    public float swayMagnitude;
    public float swayFrequency;
    private float swayTime;
    private float prevMax;

    //Land
    [Header("Landing Settings")]
    public AnimationCurve landingCurve;
    private float distanceFallen;
    private float landingTime = 0;
    public float maxDistance = 10;

    //Crouch
    [Header("Crouching Settings")]
    public AnimationCurve CrouchCurve;
    public float crouchAnimTime;
    private float crouchTime;
    public Transform crouchPos;
    public bool crouching;
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

        //Checks for issues:
    }

    // Update is called once per frame
    void Update()
    {
        offsetValues = Vector3.zero;

        CameraZoom();
        CameraSway();
        LandingCalc();
        Crouching();

        //Clamp the y so I don't clip into the ground.
        if(offsetValues.y < minY)
        {
            offsetValues.y = minY;
        }
        if(offsetValues.y < minY / 2 && crouching)
        {
            offsetValues.y = minY / 2;
        }

        transform.localPosition = initialPos + offsetValues;
    }

    /* The zoom functionality, usable without a weapon, allowing players to focus in on something.
     * 
     * Zoom is achieved through adjusting the FoV, by a percentage to respect FOV choices.
     */

    void CameraZoom()
    {
        //Are they still zooming?
        if (im.PlayerZoomedThisFrame() && !sprinting)
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

    /* Functions for the effects of the player sprinting.
     * 
     * 
     */

    void SprintEffect()
    {
        if (im.PlayerSprintingThisFrame())
        {
            sprinting = true;
            zooming = false;
        }
        else if (im.PlayerStoppedSprintingThisFrame())
        {
            sprinting = false;
        }

        if (sprintTime <= sprintAnimationTime && sprintTime >= 0)
        {
            if (sprinting)
            {
                sprintTime += Time.deltaTime;
            }
            else
            {
                sprintTime -= Time.deltaTime;
            }
        }

        //Calculate T.
        float t = zoomTime / zoomAnimationTime;

        // Give it bounds.
        t = Mathf.Clamp(t, 0, 1);

        zoomTime = Mathf.Clamp(zoomTime, 0, zoomAnimationTime);

        float fov = Mathf.Lerp(initialFOV, initialFOV * sprintFieldOfViewMod, t);

        cam.fieldOfView = fov;
    }


    /* The camera bob functionality. Vertical bob is the focus.
     * 
     * Horizontal sway should be achievable, but not desirable.
     */
    void CameraSway()
    {
        float t = player.getSpeed();

        if(t > 0)
        {

            swayTime += Time.deltaTime;

            float sinWave = Mathf.Sin(t * -swayFrequency * swayTime);
            prevMax = swayMagnitude * sinWave;

            if (sinWave <= -0.9f && !pAudio.currentlyPlaying())
            {
                pAudio.PlayFootstep();
            }
        } else
        {
            swayTime = 0;
            prevMax = Mathf.Lerp(prevMax, 0, 0.01f);
        }

        //This currently works, but it doesn't play nicely with controllers. Fix pls.
        //TODO: Fix.

        offsetValues += Vector3.up * prevMax;
    }


    /* Methods for how I deal with the landing effect.
     * 
     * 
     */
    void LandingCalc()
    {
        //Get info from the character controller that I just landed.
        //Quickly lerp down to landing position.
        //Slowly decay back to regular position.
        if (landingTime > 0)
        {
            landingTime += Time.deltaTime;

            float x = landingCurve.Evaluate(landingTime);

            offsetValues += Vector3.up * x * distanceFallen;
        }

        if(landingTime > 1)
        {
            landingTime = 0;
        }

    }

    float QuickExp(float x)
    {
        x = 1.0f + x / 256f;
        for (int i = 0; i < 8; i++)
        {
            x *= x;
        }

        return x;
    }

    public void LandingShake(float distance)
    {
        landingTime = 0.01f;

        distanceFallen = Mathf.Clamp(distance * 2, 0, maxDistance);

        pAudio.PlayFootstep();
    }


    /* Crouching Code hidden bug report.
     * 
     * 
     */

    public void Crouching()
    {
        float t = crouchTime / crouchAnimTime;

        crouchTime = Mathf.Clamp(crouchTime, 0, crouchAnimTime);

        if (crouching)
        {
            crouchTime += Time.deltaTime;

        } else
        {
            crouchTime -= Time.deltaTime;
        }

        float crouchStrength = Vector3.Distance(initialPos, crouchPos.localPosition);

        Vector3 tempVec = Vector3.up * CrouchCurve.Evaluate(t) * crouchStrength;

        offsetValues += tempVec;
    }

    public void StartCrouch()
    {
        crouching = true;
    }

    public void EndCrouch()
    {
        crouching = false;
    }
}
