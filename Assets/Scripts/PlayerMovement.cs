using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] protected float moveSpeed = 15f;
    [SerializeField] protected float jumpForce = 5f;
    [SerializeField] protected float gravityScale = 1f;

    [Header("Inputs")]
    [SerializeField] protected string HorizontalInput = "Horizontal";
    [SerializeField] protected string VerticalInput = "Vertical";
    [SerializeField] protected string JumpInput = "Jump";
    [SerializeField] protected string SprintInput = "Sprint";

    protected new Rigidbody rigidbody;
    protected new CapsuleCollider collider;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();

        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
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

        // Going forward/back and left/right at the same time creates a right triangle with magnitude sqrt(2).
        // Normalizing this makes you move at the same speed regardless of input combination.
        movementVector = movementVector.normalized;

        return movementVector *= moveSpeed; ;
    }

    protected virtual void HandleMovement(Vector3 velocity)
    {
        // Y-axis velocity is always preserved
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
    
    protected virtual void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        Debug.Log("Jumping");
    }
}