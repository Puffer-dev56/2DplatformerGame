using UnityEngine;

public class Player : MonoBehaviour
{
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

    //player Animation
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
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
}
