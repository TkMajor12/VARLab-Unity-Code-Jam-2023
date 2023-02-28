using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
<<<<<<< HEAD
    [SerializeField] private float moveSpeed = 30f;

=======
    [SerializeField] protected float moveSpeed = 15f;
    [SerializeField] protected float jumpForce = 5f;
    [SerializeField] protected float gravityScale = 1f;

    [Header("Inputs")]
>>>>>>> ed39dfb61b1daa8c9fd45558627feca68dfc55f8
    [SerializeField] protected string HorizontalInput = "Horizontal";
    [SerializeField] protected string VerticalInput = "Vertical";
    [SerializeField] protected string JumpInput = "Jump";
    [SerializeField] protected string SprintInput = "Sprint";

    protected new Rigidbody rigidbody;
    protected new CapsuleCollider collider;

<<<<<<< HEAD
    // Awake is called before the first frame update
    void Awake()
=======
    // Start is called before the first frame update
    private void Awake()
>>>>>>> ed39dfb61b1daa8c9fd45558627feca68dfc55f8
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();

        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
<<<<<<< HEAD
    void Update()
    {
        var movementVector = CalculateMovementVector();
        HandleMovement(movementVector);
    }

    protected virtual Vector3 CalculateMovementVector()
    {
        Jump();

        Vector3 movementVector = new Vector3(
            Input.GetAxisRaw(HorizontalInput) * -1,
            Input.GetAxisRaw(JumpInput),
            Input.GetAxisRaw(VerticalInput) * -1);
=======
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        HandleMovement(CalculateMovementVector());
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(Physics.gravity * (gravityScale - 1) * rigidbody.mass);
    }


    /// <summary> 
    ///     Calculates the velocity vector for regular movement
    /// </summary>
    protected virtual Vector3 CalculateMovementVector()
    {
        Vector3 movementVector = Vector3.zero;

        movementVector += transform.right * Input.GetAxisRaw(HorizontalInput) * -1;
        movementVector += transform.forward * Input.GetAxisRaw(VerticalInput) * -1;
>>>>>>> ed39dfb61b1daa8c9fd45558627feca68dfc55f8

        // Going forward/back and left/right at the same time creates a right triangle with magnitude sqrt(2).
        // Normalizing this makes you move at the same speed regardless of input combination.
        movementVector = movementVector.normalized;

<<<<<<< HEAD
        // Multiply our movement vector by our set move speed before returning it
        return movementVector * moveSpeed;
    }

    /// <summary> Updates the element's velocity </summary>
=======
        return movementVector *= moveSpeed; ;
    }

>>>>>>> ed39dfb61b1daa8c9fd45558627feca68dfc55f8
    protected virtual void HandleMovement(Vector3 velocity)
    {
        // Y-axis velocity is always preserved
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
<<<<<<< HEAD

    protected virtual void Jump()
    {
        Vector3 up = new Vector3(0, 1000, 0);
        Vector3 down = new Vector3(0, 100, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("JUMP");
            rigidbody.AddForce(up * 50, ForceMode.Force);
        }

        rigidbody.AddForce(down * (-5), ForceMode.Force);
    }
}
=======
    
    protected virtual void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        Debug.Log("Jumping");
    }
}
>>>>>>> ed39dfb61b1daa8c9fd45558627feca68dfc55f8
