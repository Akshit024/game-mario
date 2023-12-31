using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;
    // Start is called before the first frame update

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    
    private float dirx;

    private enum MovementState { idle, running, jumping, falling}
    [SerializeField] private AudioSource jumpsound;
    private int jumpleft;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        jumpleft =2;
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if(IsGrounded() && rb.velocity.y <=0 ){
            jumpleft=2;
        }
        if (Input.GetButtonDown("Jump") && jumpleft == 1) {
            anim.SetTrigger("DoubleJump");
        }
        if (Input.GetButtonDown("Jump")  && jumpleft>0)
        {
            jumpsound.Play();
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            jumpleft--;
        }
        animationState();
        
    }

    private void animationState()
    {
        MovementState state;
        if (dirx > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {           
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    //help us find if the  character is touching the ground or not.
    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }
}
