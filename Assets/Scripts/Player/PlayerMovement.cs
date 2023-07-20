using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerWalkMS;
    public float playerRunMS;
    public Vector2 moveInput;
    Rigidbody2D rb;

    [Header("Animations")]
    public Animator playerAnimation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void MovePlayer()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerWalkMS, moveInput.y * playerWalkMS);
        rb.velocity = playerVelocity;
    }
}
