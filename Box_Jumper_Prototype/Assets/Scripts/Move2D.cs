using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move2D : MonoBehaviour
{
    // RigidBody
    private Rigidbody2D rigidBody;

    // Movement and Jump
    [SerializeField] float moveSpeed = 5f;
    private float moveInput;
    [SerializeField] float jumpHeight = 5f;
    //public bool isGrounded = true;
    [SerializeField] public int jumpCount = 0;
    [SerializeField] TextMeshProUGUI jumpCounter;

    // Dash
    [SerializeField] public float dashSpeed;
    private float dashTime;
    [SerializeField] public float startDashTime;
    private int direction;
    [SerializeField] public int dashCount = 0;
    [SerializeField] TextMeshProUGUI dashCounter;



    // Start is called before the first frame update
    void Start()
    {
        jumpCounter.text = "Jumps: " + jumpCount.ToString();
        jumpCounter.text = "Dash: " + dashCount.ToString();
        rigidBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        Jump();
        MoveLeftRight();
        Dash();

    }

    private void MoveLeftRight()
    {
        Vector3 movement = new Vector3(moveInput, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    private void JumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse); // Add Force
            rigidBody.velocity = new Vector2(0f, jumpHeight);  // Add Velocity
            jumpCount--;

        }
    }

    private void Jump()
    {
        jumpCounter.text = "Jumps: " + jumpCount.ToString();
        if (jumpCount > 0)
        {
            JumpInput();
        }
    }

    private void DashInput()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (moveInput < 0)
                {
                    direction = 1;
                }
                else if (moveInput > 0)
                {
                    direction = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                dashCount--;
                direction = 0;
                dashTime = startDashTime;
                rigidBody.velocity = Vector2.zero;
                
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rigidBody.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rigidBody.velocity = Vector2.right * dashSpeed;
                }
                
            }
        }
    }

    private void Dash()
    {
        dashCounter.text = "Dash: " + dashCount.ToString();
        if (dashCount > 0)
        {
            DashInput();
        }
    }
    
}
