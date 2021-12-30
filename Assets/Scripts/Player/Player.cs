using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    BoxCollider2D boxCollider;
    Animator anim;
    PlayerStats stats;
    AudioManager audiom;

    bool isGrounded, isRunning, isCrouching, allowDoubleJump, defending;
    float horizontalInput;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float moveSpeed = 5, jumpSpeed = 12.5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        stats = GetComponent<PlayerStats>();
        audiom = GetComponent<AudioManager>();
        allowDoubleJump = true;
    }

    void Update()
    {
        // Sideways Movement
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);

        // Player Direction Right and Left
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
        transform.localScale = new Vector3(-1, 1, 1);

        // Animations
        isGrounded = GroundCollision();

        // Run
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded);
        isRunning = horizontalInput != 0;


        // Jump
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Normal Jump
            if (isGrounded) {
                audiom.Play("Jump", false);
                allowDoubleJump = true;
                Jump();
            }
            // Double Jump
            if (!isGrounded && allowDoubleJump) {
                allowDoubleJump = false;
                Jump();
            }
        }

        // Defend
        if (Input.GetKey(KeyCode.F))
        {
            defending = true;
        } else if (Input.GetKeyUp(KeyCode.F)) defending = false;
    }


    void Jump()
    {
        anim.SetTrigger("Jump");
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
    }

    public void takeDamage(float damage)
    {
        audiom.Play("GetHit", false);
        anim.SetTrigger("PlayerTakesDamage");
        if (defending) stats.updateHealth(damage / 2);
        else if (!defending) stats.updateHealth(damage);
    }

    bool GroundCollision()
    {
        RaycastHit2D ray = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return ray.collider != null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            stats.addHealth();
            Destroy(collision.gameObject);
        }
    }
}
