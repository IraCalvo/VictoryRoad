using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public float playerWalkMS;
    public float playerRunMS;
    public Vector2 moveInput;
    public bool playerCanMove = true;
    Rigidbody2D rb;
    public LayerMask grassLayer;
    public float rayCastDistance = 1f;

    [Header("Animations")]
    public Animator playerAnimation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();

        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
        playPlayerAnimation();
    }

    void OnMove(InputValue value)
    {
        if (playerCanMove)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    void MovePlayer()
    {
        if (playerCanMove)
        {
            CheckIfGrass();
            Vector2 playerVelocity = new Vector2(moveInput.x * playerWalkMS, moveInput.y * playerWalkMS);
            rb.velocity = playerVelocity;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void playPlayerAnimation()
    {
        if(moveInput.x == 0 && moveInput.y == 1)
        {
            playerAnimation.SetBool("isWalkingUp", true);
            playerAnimation.SetBool("isWalkingDown", false);
            playerAnimation.SetBool("isWalkingRight", false);
            playerAnimation.SetBool("isWalkingLeft", false);
        }

        if (moveInput.x == 0 && moveInput.y == -1)
        {
            playerAnimation.SetBool("isWalkingUp", false);
            playerAnimation.SetBool("isWalkingDown", true);
            playerAnimation.SetBool("isWalkingRight", false);
            playerAnimation.SetBool("isWalkingLeft", false);
        }

        if (moveInput.x == 1 && moveInput.y == 0)
        {
            playerAnimation.SetBool("isWalkingUp", false);
            playerAnimation.SetBool("isWalkingDown", false);
            playerAnimation.SetBool("isWalkingRight", true);
            playerAnimation.SetBool("isWalkingLeft", false);
        }

        if (moveInput.x == -1 && moveInput.y == 0)
        {
            playerAnimation.SetBool("isWalkingUp", false);
            playerAnimation.SetBool("isWalkingDown", false);
            playerAnimation.SetBool("isWalkingRight", false);
            playerAnimation.SetBool("isWalkingLeft", true);
        }
    }

    void CheckIfGrass()
    {
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            Vector2 rayCastDirection = new Vector2(moveInput.x, moveInput.y).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayCastDirection, rayCastDistance, grassLayer);

            if (hit.collider != null)
            {
                Grass grass = hit.collider.gameObject.GetComponent<Grass>();
                grass.CheckIfBattle();
            }
        }
    }
}
