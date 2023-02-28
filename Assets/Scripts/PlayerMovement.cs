using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected new Rigidbody rigidbody;
    protected new CapsuleCollider collider;

    [Header("Movement Values")]
    [SerializeField] private float moveSpeed = 30f;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}
