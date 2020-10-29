using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    public static Player Obj;
    
    public int lives = 3;
    
    public bool isGrounded = false;
    public bool isMoving = false;

    private const float Speed = 1.5f;
    private const float JumpForce = 3f;
    private float movHor;

    public float immuneTimeCnt = 0f;
    public float immuneTime = 0.5f;

    public LayerMask groundLayer;
    public float radius = 0.3f;
    private float groundRayDist = 0.1f;

    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _spr;


    private void Awake()
    {
        Obj = this;
    }

    private void OnDestroy()
    {
        Obj = null;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");

        isMoving = (movHor != 0f);

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer); 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }      
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shot();
        }
        
        _anim.SetBool("isMoving",isMoving);
        _anim.SetBool("isGrounded",isGrounded);
        
        Flip(movHor);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(movHor *Speed, _rb.velocity.y);
    }

    private void Jump()
    {
        if (!isGrounded) return;
        
        _rb.velocity = Vector2.up * JumpForce;
    }

    private void Shot()
    {
        
    }

    private void Flip(float xValue)
    {
        Vector3 theScale = transform.localScale;

        if (xValue < 0)
        {
            theScale.x = Mathf.Abs(theScale.x) * -1;
        }

        if (xValue > 0)
        {
            theScale.x = Mathf.Abs(theScale.x);
        }

        transform.localScale = theScale;

        {
            
        }
    }
}
