using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public float walkSpeed = 1;
    
    public bool mustPatrol;
    public LayerMask wallLayer;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Collider2D groundCheck;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol && groundCheck.IsTouchingLayers(groundLayer))
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if(bodyCollider.IsTouchingLayers(wallLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }




}
