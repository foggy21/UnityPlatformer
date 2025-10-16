using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector2 velocity;
    public float currentInput;
    public float movementDelta = 3f;
    public float jumpForce = 5f;
    public bool isGrounded;
    public LayerMask groundLayer;
    private void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        if (velocity.x != 0)
        {
            currentInput = Mathf.MoveTowards(currentInput, velocity.x, Time.deltaTime * movementDelta);
        }
        else
        {
            currentInput = 0;
        }
        rb2d.velocity = new Vector2(currentInput, rb2d.velocity.y);

        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y  - 0.5f), 
            0.5f, groundLayer);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, rb2d.velocity.y + jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y  - 0.5f), 0.5f);
    }
}
