using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float moveSpeed = 30f;

    [SerializeField] protected string HorizontalInput = "Horizontal";
    [SerializeField] protected string VerticalInput = "Vertical";
    [SerializeField] protected string JumpInput = "Jump";
    [SerializeField] protected string SprintInput = "Sprint";

    protected new Rigidbody rigidbody;
    protected new CapsuleCollider collider;

    // Awake is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();

        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
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

        // Going forward/back and left/right at the same time creates a right triangle with magnitude sqrt(2).
        // Normalizing this makes you move at the same speed regardless of input combination.
        movementVector = movementVector.normalized;

        // Multiply our movement vector by our set move speed before returning it
        return movementVector * moveSpeed;
    }

    /// <summary> Updates the element's velocity </summary>
    protected virtual void HandleMovement(Vector3 velocity)
    {
        // Y-axis velocity is always preserved
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }

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
