using UnityEngine;

public class Cat_Walk : MonoBehaviour
{
    private Animator animator;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Animator bile�enine eri�iyoruz
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hareket giri�lerini almak
        float moveX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveX, 0); // Sadece x y�n�nde hareket

        // E�er x y�n�nde hareket varsa animasyonu ba�lat
        if (movement.x != 0)
        {
            animator.SetBool("isWalking", true); // Y�r�y�� animasyonunu ba�lat

            // Kedi sa�a gidiyorsa normal, sola gidiyorsa ters y�n bakacak �ekilde ayarla
            if (movement.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // Sa�a bak
            }
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Sola bak
            }
        }
        else
        {
            // Hareket yoksa y�r�y�� animasyonunu durdur
            animator.SetBool("isWalking", false);
        }

        // Kediyi hareket ettir
        transform.Translate(movement * Time.deltaTime * 5f); // Hareket h�z� 5
    }
}
