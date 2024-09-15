using UnityEngine;

public class Cat_Walk : MonoBehaviour
{
    private Animator animator;   // Animator bileşeni
    private Rigidbody2D rb;      // Rigidbody2D bileşeni
    private Vector2 movement;    // Hareket vektörü

    public float moveSpeed = 5f; // Hareket hızı
    public float jumpForce = 10f; // Zıplama kuvveti
    private bool isGrounded = true; // Karakterin yerde olup olmadığını kontrol etmek

    public Transform groundCheck; // Yerde kontrol noktası
    public float groundCheckRadius = 0.2f; // Kontrol noktası yarıçapı
    public LayerMask groundLayer; // Yerin hangi katman olduğunu belirlemek

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Yatay hareket girişini al
        movement.x = Input.GetAxisRaw("Horizontal");

        // Zıplama girişini kontrol et
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Yürüyüş animasyonunu kontrol et
        if (movement.x != 0)
        {
            animator.SetBool("isWalking", true);

            // Sağ tarafa bak
            if (movement.x > 0)
            {
                transform.localScale = new Vector3(3, 3, 3);
            }
            // Sol tarafa bak
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-3, 3, 3);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Zıplama animasyonunu kontrol et
        animator.SetBool("isJumping", !isGrounded);
    }

    void FixedUpdate()
    {
        // Hareketi uygula
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);

        // Yerde olup olmadığını kontrol et
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Jump()
    {
        // Zıplama kuvveti uygula
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}
