using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Life life;
    TrailRenderer trailRend;

    [Header("Stats")]
    [SerializeField] float speed;
    [SerializeField] float jump;

    [Header("Dash")]
    [SerializeField] float dashDuration;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCooldown;
    bool isDashing;
    bool canDash;

    [Header("HUD")]
    [SerializeField] TextMeshProUGUI coinsTXT;
    [SerializeField] TextMeshProUGUI healthTXT;

    [Header("GroundCheck")]
    [SerializeField] Vector3 boxOffset;
    [SerializeField] float boxWidth;
    [SerializeField] float boxHeight;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;
    bool canDoubleJump;

    [Header("Death")]
    [SerializeField] float gameoverDuration;
    [SerializeField] GameObject explosionSparks;
    public bool isDead;

    [Header("Audio")]
    


    bool isFlipped;
    int coinsGotten;
    int healthReceived;
    public Vector3 respawnPosition;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        canDoubleJump = true;
        isDead = false;
        animator = GetComponent<Animator>();
        life = GetComponent<Life>();
        canDash = true;
        trailRend = FindObjectOfType<TrailRenderer>();
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        coinsTXT.text = "Coins: " + coinsGotten;
        healthTXT.text = "HP: " + life.GetHealth();
        Death();
        if (!isDead)
        {
            IsGrounded();
            Dash();
            if (!isDashing)
            {
                Movement();
                Flip();
                Jump();
            }
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || canDoubleJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            CanDoubleJump();
            animator.SetTrigger("jump");
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        animator.SetFloat("xVel", Mathf.Abs(rb.velocity.x));
    }

    private void IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position + boxOffset, new Vector2(boxWidth, boxHeight), 0, Vector2.down, boxHeight, groundLayer).collider == null)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
            canDoubleJump = true;
        }
        animator.SetBool("isGrounded", isGrounded);
    }

    private void CanDoubleJump()
    {
        if (!isGrounded)
        {
            canDoubleJump = false;
        }
    }

    private void Flip()
    {
        if(rb.velocity.x < 0 & !isFlipped)
        {
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
        else if(rb.velocity.x > 0 & isFlipped)
        {
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
    }

    public void GetCoin(int value)
    {
        coinsGotten += value; 
    }

    private void Death()
    {
        if(life.GetHealth() <= 0 && !isDead)
        {
            StartCoroutine(DeathCoroutine());
        }
    }
    IEnumerator DeathCoroutine()
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        animator.SetTrigger("isDead");
        Instantiate(explosionSparks, transform.position, transform.rotation);
        life.Heal(5);
        animator.SetTrigger("Revive");
        //animator.ResetTrigger("isDead");
        yield return new WaitForSeconds(gameoverDuration);
        transform.position = respawnPosition;
        isDead = false;
    }
    private void Dash()
    {
        if(Input.GetButtonDown("Fire3") && canDash)
        {
            rb.velocity = transform.right * dashSpeed;
            rb.gravityScale = 0;
            StartCoroutine(DashCoroutine());
        }
    }
    IEnumerator DashCoroutine()
    {
        isDashing = true;
        canDash = false;
        life.isVunerable = false;
        trailRend.emitting = true;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        life.isVunerable = true;
        trailRend.emitting = false;
        rb.gravityScale = 3;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + boxOffset, new Vector2(boxWidth, boxHeight * 2));
    }
}
