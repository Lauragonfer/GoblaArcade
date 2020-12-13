using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;

    public GameObject enemy;

    private float _startingTime;
    public float livingTime = 6f;
    
    public float speed = 3f;
    public float movHor = 1f;
    
    public int scoreGive = 50;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startingTime = Time.time;
		
        Destroy(gameObject, livingTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("wall"))
        {
            movHor = movHor * -1;
        }
        
    }

    private void FixedUpdate()
    {
       _rb.velocity = new Vector2(movHor * speed, _rb.velocity.y); ;
    }

    private void TransformToEnemy()
    { 
       Instantiate(enemy, transform.position, transform.rotation);
       this.gameObject.SetActive(false);
    }

}
