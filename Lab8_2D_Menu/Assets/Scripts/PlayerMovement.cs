using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 5f;

    Vector2 movementVector;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        Vector2 playerVelocity = new Vector2(movementVector.x * movementSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

    }

    private void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        Debug.Log(movementVector);
    }

    private void OnJump(InputValue value)
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpHeight);
        }
    }
}
