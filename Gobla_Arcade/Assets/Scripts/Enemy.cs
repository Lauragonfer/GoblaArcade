
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float speed = 3f;
    public float movHor = 1f;

    public bool isGroundFloor = true;
    public bool isGroundFront = false;

    public LayerMask groundLayer;
    public float frontGrndRayDist = 0.25f;
    public float floorCheckY = 0.52f;
    public float frontCheck = 3f;
    public float frontDisct = 0.1f;

    public int scoreGive = 50;

    private RaycastHit2D hit;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isGroundFloor = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z),
            new Vector3(movHor, 0, 0), frontGrndRayDist, groundLayer));
        
        if (!isGroundFloor)
        {
            movHor = movHor * -1;
        }

        if (Physics2D.Raycast(transform.position, new Vector3(movHor, 0, 0), frontCheck, groundLayer))
        {
            movHor = movHor * -1;
        }

        hit = Physics2D.Raycast(
            new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z),
            new Vector3(movHor, 0, 0), frontDisct);

        Flip(movHor);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Chocan ENEMIGOS");
            movHor = movHor * -1;
            Flip(movHor);
        }
        
    }

    private void FixedUpdate()
    {
       _rb.velocity = new Vector2(movHor * speed, _rb.velocity.y); ;
    }

    private void getKilled()
    {
        gameObject.SetActive(false);
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
