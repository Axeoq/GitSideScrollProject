using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1f;
    public float jumpForce = 3f;
    ///int groundLayer();

    private Animator animator; 

    private Rigidbody2D rb; 
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        ///groundLayer = LayerMask.GetMask("Ground");
        animator = GetComponent <Animator>();
    }

    private void SpriteFlip (float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            sr.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            sr.flipX = true;
        }
    }

    private void PlayRun()
    {
        animator.SetTrigger("goRun");
    }
    private void PlayJump()
    {
        animator.SetTrigger("goJump");
    }
    private void PlayIdle()
    {
        animator.SetTrigger("goIdle");
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalInput);

        if (horizontalInput != 0) PlayRun();
        else PlayIdle();

        if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            PlayJump();
        }
    }
}
