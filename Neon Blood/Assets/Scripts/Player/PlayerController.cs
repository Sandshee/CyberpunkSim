using System.Collections;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private InputManager im;
    public CameraAnims camAn;

    [Header("Movement")]
    public float speed = 5f;
    public float airMod = 0.5f;
    private float slopeLimit;
    private float stepOffset;

    private Vector3 previousPosition;

    [Header("Grounded Check")]

    public Transform groundCheck;
    public Transform headCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded = false;
    public float zeroGravity = -2f;

    [Header("Jumping & Landing")]

    private bool canJump = true;
    public float landingLag = 1f;
    private int coroutineCount = 0;
    public float jumpHeight;
    private float jumpForce;
    private Vector3 startingJump;

    [SerializeField]
    public UnityEvent m_Landing;

    [Header("Crouching")]

    public float crouchMod;
    private bool crouching = false;
    private bool queueUncrouch = false;
    public float crouchingHeight;
    private float standingHeight;

    [Header("Physics")]

    private Vector3 velocity;
    private float gravity;
    public float mass;
    public float interactDistance = 0.5f;
    public Transform hands;


    // Start is called before the first frame update
    void Awake()
    {
        previousPosition = transform.position;
        cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        startingJump = transform.position;
        im = InputManager.Instance;
        gravity = Physics.gravity.y;
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * gravity * mass);
        slopeLimit = cc.slopeLimit;
        stepOffset = cc.stepOffset;
        standingHeight = cc.height;
    }

    // Update is called once per frame
    void Update()
    {
        Grounded();

        CrouchCheck();

        if (im.PlayerInteractedThisFrame())
        {
            Interact();
        }

        MovePlayer(im.GetPlayerMovement());

        if (im.PlayerJumpedThisFrame() && isGrounded)
        {
            Jump();
        }

        velocity.y += gravity * mass * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        if(velocity.y >= 0)
        {
            startingJump = transform.position;
        }
    }

    /* Grounded Check methods
     * For the grounded methods, and jumping.
     * 
     */
    private void Grounded()
    {
        //Was I grounded last frame -> Used to detect if I just landed.
        bool wasGrounded = isGrounded;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = zeroGravity;
        }

        //Just hit my head on the ceiling, owie, prevents the stuck head functionality.
        if (!isGrounded && Physics.CheckSphere(headCheck.position, groundDistance, groundMask))
        {
            velocity.y = zeroGravity/2;
        }

        if(!wasGrounded && isGrounded)
        {
            //I've just landed, implement Landing Lag.
            camAn.LandingShake(Vector3.Distance(transform.position, startingJump));
            StartCoroutine(WaitForNextJump());
            cc.slopeLimit = slopeLimit;
            cc.stepOffset = stepOffset;
        }

        if(wasGrounded && !isGrounded)
        {
            startingJump = transform.position;
        }

    }

    void Jump()
    {
        //If I'm unable to jump, why bother?
        if (!canJump)
        {
            return;
        }
        //Removes any additional vertical component to the velocity.
        velocity = Vector3.up * jumpForce;
        cc.slopeLimit = 0;
        cc.stepOffset = 0;

        canJump = false;
    }

    IEnumerator WaitForNextJump()
    {
        coroutineCount++;
        yield return new WaitForSeconds(landingLag);
        coroutineCount--;

        if(coroutineCount == 0)
        {
            canJump = true;
        }

        if(coroutineCount < 0)
        {
            Debug.LogError("Negative number of coroutines finished");
            Debug.Break();
        }
    }

    /* Movement methods
     *
     * for moving the player character, and converting vectors.
     */

    void MovePlayer(Vector2 inputs)
    {
        previousPosition = transform.position;
        float tempSpeed = speed;
        if (!isGrounded)
        {
            tempSpeed *= airMod;
        } else if (crouching)
        {
            tempSpeed *= crouchMod;
        }
        cc.Move(GetRelativeInputs(inputs) * Time.deltaTime * tempSpeed);
    }

    private Vector3 GetHorizontalComponents(Vector2 inVector)
    {
        return new Vector3(inVector.x, 0f, inVector.y);
    }

    private Vector3 GetHorizontalComponents(Vector3 inVector)
    {
        return new Vector3(inVector.x, 0f, inVector.z);
    }

    private Vector3 GetRelativeInputs(Vector2 inVector)
    {
        return transform.right * inVector.x + transform.forward * inVector.y;
    }

    public float getSpeed()
    {
        if (isGrounded)
        {
            float t = im.GetPlayerMovement().SqrMagnitude();

            t = Mathf.Clamp(t, 0, 1);

            if (crouching)
            {
                t *= 0.5f;
            }

            return t;
        } else
        {
            //Can't be walking in the air?
            return 0;
        }
    }

    /* The crouching methods
     * 
     */

    void CrouchCheck()
    {
        if (im.PlayerCrouchedThisFrame())
        {
            crouching = true;
            queueUncrouch = false;
            cc.height = crouchingHeight;
            cc.center = new Vector3(0, crouchingHeight / 2f, 0);
            camAn.StartCrouch();

            //transform.localScale = crouchingScale;
            //transform.position = Vector3.Scale(prevPos, crouchingScale);
            //Debug.Break();
            Debug.Log("My knees!");
        } else if (im.PlayerUncrouchedThisFrame())
        {
            //I want to get up.
            queueUncrouch = true;
        }

        //See if there's space above my head first.
        if (queueUncrouch && !Physics.CheckSphere(headCheck.position, groundDistance, groundMask))
        {
            crouching = false;
            queueUncrouch = false;
            camAn.EndCrouch();
            cc.height = standingHeight;
            cc.center = new Vector3(0, standingHeight / 2, 0);

        }
    }

    void Interact()
    {
        RaycastHit objectHit;

        bool hit = Physics.Raycast(camAn.gameObject.transform.position, camAn.gameObject.transform.forward, out objectHit, interactDistance);
        Debug.DrawRay(camAn.gameObject.transform.position, camAn.gameObject.transform.forward, Color.red, interactDistance);

        Debug.Log("ButterFingers " + hit);

        if (hit && objectHit.collider.CompareTag("Pickup"))
        {
            objectHit.collider.gameObject.GetComponent<PhysicsProp>().Pickup(hands);
            Debug.Log("Why are you not picked up?");
        }
    }
}
