using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    [SerializeField] Move2D movement;


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Jump Ground")
    //    {
    //        movement.isGrounded = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Jump Ground")
    //    {
    //        movement.isGrounded = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jump Ground"))
        {
            movement.jumpCount++;
        } else if (collision.CompareTag("Dash Ground"))
        {
            movement.dashCount++;
        }
        collision.tag = "Untagged";
    }
}