using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TMP_Text coinsText;
    [SerializeField] private int coins;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coinsText.text = coins.ToString();
    }

    void Update()
    {
        HandleJump();
    }

    void FixedUpdate()
    {
        HandleMovement();
        CheckGrounded();
        UpdateAnimations();
    }

    void HandleMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip sprite
        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
    }

    void UpdateAnimations()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Coin"); 
        {
            coinsText.text = coins.ToString();
            coins++;
            Destroy(other.gameObject);
        }
    }

}