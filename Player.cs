using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //heath
    public int health;
    private SpriteRenderer spriteRenderer;
    private int knockback = 100;

    //player walk
    private Rigidbody2D rb;
    public int speed;
    private float moveX;

    //player jump
    public int jumpForce;
    private bool isGrounded;
    public Transform CheckGround;
    public LayerMask GroundLayer;
    public float CheckGroundRadius;
    public int extraJump = 1;
    private int deExtraJump;

    //player Animation
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        deExtraJump = extraJump;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump")) {

            if (isGrounded) {
                rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
                deExtraJump = extraJump;
            }
            else if(deExtraJump > 0) {
                rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
                deExtraJump--;
            }
        }
        SetAnimation();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(CheckGround.position, CheckGroundRadius, GroundLayer);
    }
    private void SetAnimation() {
        if (isGrounded)
        {
            if (moveX == 0)
            {
                animator.Play("player_idle");
            }
            else
            {
                animator.Play("player_run");
            }
        }
        else {
            if (rb.linearVelocityY > 0) {
                animator.Play("player_jump");

            }
            else {
                animator.Play("player_fall");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage")) {
            health -= 1;
            rb.AddForce(new Vector2(rb.linearVelocity.y, knockback));
            StartCoroutine(BlinkRed());

            if (health <= 0) {
                Die();
            }
        }
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator BlinkRed() { 
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
