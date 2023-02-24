using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, jumpSpeed, groundCheckRadius;
    private Rigidbody2D myRB;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public AudioSource jumpSound;
    
    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Player ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //Player movement
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRB.velocity = new Vector3(moveSpeed, myRB.velocity.y, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRB.velocity = new Vector3(-moveSpeed, myRB.velocity.y, 0f);
        }
        else
        {
            myRB.velocity = new Vector3(0f, myRB.velocity.y, 0f);
        }

        //Player jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRB.velocity = new Vector3(myRB.velocity.x, jumpSpeed, 0f);
            jumpSound.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Kill Plane")
        {
            gameObject.SetActive(false);
        }
    }
}