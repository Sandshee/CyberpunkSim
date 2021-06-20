using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private InputManager im;

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
    private bool canJump = true;
    public float landingLag = 1f;
    private int coroutineCount = 0;

    [Header("Physics")]

    private Vector3 velocity;
    private float gravity;
    public float mass;
    public float jumpHeight;
    private float jumpForce;

    // Start is called before the first frame update
    void Awake()
    {
        previousPosition = transform.position;
        cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        im = InputManager.Instance;
        gravity = Physics.gravity.y;
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * gravity * mass);
        slopeLimit = cc.slopeLimit;
        stepOffset = cc.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        Grounded();

        MovePlayer(im.GetPlayerMovement());

        if (im.PlayerJumpedThisFrame() && isGrounded)
        {
            Jump();
        }

        velocity.y += gravity * mass * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
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
            //TODO: Landing lag.
            StartCoroutine(WaitForNextJump());
            cc.slopeLimit = slopeLimit;
            cc.stepOffset = stepOffset;
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
        float t = im.GetPlayerMovement().SqrMagnitude();
        Debug.Log("Speed = " + t);
        if(t > 1)
        {
            Debug.LogWarning("Speed is over 1");
        }

        return Mathf.Clamp(t, 0, 1);
    }
}
