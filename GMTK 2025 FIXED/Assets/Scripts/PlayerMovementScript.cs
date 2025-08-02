using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float MoveSpeed;

    [Header("Jumping")]
    [SerializeField] float JumpPower;
    [SerializeField] float JumpTime;
    [SerializeField] float JumpTimer;
    [SerializeField] bool IsJumping;
    [SerializeField] float gravityAccel;
    [SerializeField] float initialGravity;

    [Header("Grounding")]
    public bool Grounded;
    public LayerMask WhatIsGround;
    [SerializeField] float CheckRadius;
    public Transform childPos;

    [Header("Direction")]
    [SerializeField] bool IsFacingRight;

    [Header("References")]
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        BC = GetComponent<BoxCollider2D>();
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        initialGravity = RB.gravityScale;
        IsJumping = false;
        JumpTimer = 0;
        IsFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GroundCheck();
        Jump();

        
    }

    private void Move()
    {
        RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, RB.velocity.y);
        CheckFlip();

        if (Input.GetAxisRaw("Horizontal") != 0 && Grounded)
        {
            anim.SetBool("Running", true);

            anim.SetBool("Laying", false);
            anim.SetBool("Licking", false);
            anim.SetBool("Scratching", false);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

    private void GroundCheck()
    {
        Grounded = Physics2D.OverlapCircle(childPos.position, CheckRadius, WhatIsGround);

        if (Grounded)
        {
            IsJumping = false;
            JumpTimer = 0;
            RB.gravityScale = initialGravity;
            anim.SetBool("Jumping", false);
        }
        else
        {
            anim.SetBool("Jumping", true);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            RB.velocity = new Vector2(RB.velocity.x, JumpPower);
            IsJumping = true;
            JumpTimer = 0;

            anim.SetBool("Laying", false);
            anim.SetBool("Licking", false);
            anim.SetBool("Scratching", false);
        }

        if (Input.GetKey(KeyCode.Space) && IsJumping)
        {
            if (JumpTimer < JumpTime)
            {
                RB.velocity = new Vector2(RB.velocity.x, JumpPower);
                JumpTimer += Time.deltaTime;
            }
            else
            {
                IsJumping = false;
                RB.gravityScale *= gravityAccel;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space) && !Grounded)
        {
            IsJumping = false;
            RB.gravityScale *= gravityAccel;
        }


    }

    private void CheckFlip()
    {
        if (IsFacingRight && Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            IsFacingRight = !IsFacingRight;
        }
    }
}
