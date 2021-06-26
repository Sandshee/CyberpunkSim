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
    public float maxSpeed = 5f;
    private float speed = 0f;
    public float accelleration = 0.1f;
    public float airMod = 0.5f;
    private float slopeLimit;
    private float stepOffset;
    public float landingMod = 0.25f;

    private Vector3 horizontalVel;
    public float drag;

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
    public float maxLandingTime;

    [Header("Crouching")]

    public float crouchMod;
    private bool crouching = false;
    private bool queueUncrouch = false;
    public float crouchingHeight;
    private float standingHeight;
    public Transform crouchingHeadCheck;

    [Header("Physics")]

    private Vector3 velocity;
    private float gravity;
    public float mass;
    public float interactDistance = 0.5f;
    public Transform hands;
    private PhysicsProp heldItem;

    private Ladder ladder;
    private float ladderPCT;
    private bool isClimbing = false;
    public float climbSpeed;

    [Header("Slopes")]
    public float slipAccel;
    public bool sliding;

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

        if (isClimbing)
        {
            Climbing();
        }

        if (im.PlayerInteractedThisFrame())
        {
            Interact();
        }

        Slide();

        if (!sliding)
        {
            MovePlayer(im.GetPlayerMovement());
        }

        if (im.PlayerJumpedThisFrame() && isGrounded)
        {
            Jump();
        }

        if (!isClimbing)
        {
            //The player falls down, affected by Gravity.
            velocity.y += gravity * mass * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
        }

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
        if(crouching)
        {
            if (!isGrounded && Physics.CheckSphere(crouchingHeadCheck.position, groundDistance, groundMask))
            {
                velocity.y = zeroGravity / 2;
            }
        } else if (!isGrounded && Physics.CheckSphere(headCheck.position, groundDistance, groundMask))
        {
            velocity.y = zeroGravity / 2;
        }

        if(!wasGrounded && isGrounded)
        {
            //I've just landed, implement Landing Lag.
            camAn.LandingShake(Vector3.Distance(transform.position, startingJump));
            StartCoroutine(WaitForNextJump(Vector3.Distance(transform.position, startingJump)));
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
        isGrounded = false;
    }

    IEnumerator WaitForNextJump(float modifier)
    {
        modifier = Mathf.Clamp(modifier * landingLag, 0, maxLandingTime * landingLag)/landingLag;
        coroutineCount++;
        yield return new WaitForSeconds(landingLag * modifier);
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
        if (!isClimbing)
        {
            previousPosition = transform.position;

            //If the player is on the ground, they can stop moving without input.
            if (isGrounded && inputs == Vector2.zero)
            {
                Drag();
            }

            //If the player is in the air, their accelleration is modified;

            Vector3 relativeInputs = GetRelativeInputs(inputs);

            if (!isGrounded)
            {
                horizontalVel += relativeInputs * accelleration * airMod;
            }
            else
            {
                horizontalVel += relativeInputs * accelleration;
            }

            //Deal with the different max speeds, depending on the player's current state.
            float currentMaxSpeed = maxSpeed;

            if (crouching)
            {
                currentMaxSpeed *= crouchMod;
            }

            if (isGrounded && !canJump)
            {
                currentMaxSpeed *= landingMod;
            }

            //Clamp the velocity to a maximum value.
            if (horizontalVel.sqrMagnitude > currentMaxSpeed * currentMaxSpeed)
            {
                horizontalVel = horizontalVel.normalized * currentMaxSpeed;
            }

            cc.Move(horizontalVel * Time.deltaTime);
        } else
        {
            horizontalVel = Vector3.zero;
        }
    }

    void Drag()
    {
        if (!sliding)
        {
            horizontalVel = horizontalVel / drag;
        }
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
        if (queueUncrouch && !Physics.CheckSphere(headCheck.position, groundDistance, groundMask) && !Physics.CheckSphere(crouchingHeadCheck.position, groundDistance, groundMask))
        {
            crouching = false;
            queueUncrouch = false;
            camAn.EndCrouch();
            cc.height = standingHeight;
            cc.center = new Vector3(0, standingHeight / 2, 0);

        }
    }

    /* The interactables, buttons etc.
     * 
     * 
     */

    void Interact()
    {

        if (heldItem)
        {
            heldItem.PutDown();
            heldItem = null;
        }

        else if (isClimbing)
        {
            StopClimbing();
        }

        else
        {
            RaycastHit objectHit;

            bool hit = Physics.Raycast(camAn.gameObject.transform.position, camAn.gameObject.transform.forward, out objectHit, interactDistance);

            if (hit)
            {
                //Picking up an item.
                if (objectHit.collider.CompareTag("Pickup"))
                {
                    heldItem = objectHit.collider.gameObject.GetComponent<PhysicsProp>();

                    heldItem.Pickup(hands);
                }

                if (objectHit.collider.CompareTag("Button"))
                {
                    objectHit.collider.gameObject.GetComponent<Button>().Activate();
                }

                //Using a ladder.
                if (objectHit.collider.CompareTag("Ladder"))
                {
                    isClimbing = true;
                    ladder = objectHit.collider.gameObject.GetComponent<Ladder>();
                    transform.position = ladder.Connect(transform.position);
                }
            }
        }
    }

    void Slide()
    {
        RaycastHit rayHit;

        Physics.Raycast(groundCheck.position, Vector3.down, out rayHit, 1f, groundMask);

        Vector3 normal = rayHit.normal;
        Debug.Log("Y value: " + normal.y);
        Debug.DrawRay(groundCheck.position, normal, Color.red, 2f);
        if (normal.y <= 0.5 && normal.y > 0)
        {
            sliding = true;
            //cc.Move(GetHorizontalComponents(normal));
            //MovePlayer(GetHorizontalComponents(normal));
            horizontalVel += GetHorizontalComponents(normal * slipAccel);
            cc.Move(horizontalVel * Time.deltaTime);
        } else
        {
            sliding = false;
        }
    }

    void Climbing()
    {
        float up = im.GetPlayerMovement().y;

        Vector3 desiredPosition = ladder.Climb(up, climbSpeed * Time.deltaTime);
        if (desiredPosition == Vector3.zero)
        {
            StopClimbing();
        }
        else
        {
            transform.position = desiredPosition;
        }
    }

    void StopClimbing()
    {
        ladder = null;
        isClimbing = false;
    }
}
