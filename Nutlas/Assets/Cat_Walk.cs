using UnityEngine;

public class Cat_Walk : MonoBehaviour
{
    private Animator animator;   // Animator bile�eni
    private Rigidbody2D rb;      // Rigidbody2D bile�eni
    private Vector2 movement;    // Hareket vekt�r�

    public float moveSpeed = 5f; // Hareket h�z�

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody ve Animator bile�enlerini al
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Kullan�c�dan yatay eksende giri� al
        movement.x = Input.GetAxisRaw("Horizontal");

        // Y�r�y�� animasyonunu kontrol et
        if (movement.x != 0)
        {
            animator.SetBool("isWalking", true); // Animasyonu ba�lat

            // Sa� tarafa do�ru hareket
            if (movement.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // Normal y�n
            }
            // Sol tarafa do�ru hareket
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Ters y�n
            }
        }
        else
        {
            animator.SetBool("isWalking", false); // Animasyonu durdur
        }
    }

    // Fizik i�lemleri burada yap�l�r
    void FixedUpdate()
    {
        // Rigidbody ile kediyi hareket ettir
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
}