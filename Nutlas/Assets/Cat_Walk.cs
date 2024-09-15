using UnityEngine;

public class Cat_Walk : MonoBehaviour
{
    private Animator animator;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Animator bileþenine eriþiyoruz
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hareket giriþlerini almak
        float moveX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveX, 0); // Sadece x yönünde hareket

        // Eðer x yönünde hareket varsa animasyonu baþlat
        if (movement.x != 0)
        {
            animator.SetBool("isWalking", true); // Yürüyüþ animasyonunu baþlat

            // Kedi saða gidiyorsa normal, sola gidiyorsa ters yön bakacak þekilde ayarla
            if (movement.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // Saða bak
            }
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Sola bak
            }
        }
        else
        {
            // Hareket yoksa yürüyüþ animasyonunu durdur
            animator.SetBool("isWalking", false);
        }

        // Kediyi hareket ettir
        transform.Translate(movement * Time.deltaTime * 5f); // Hareket hýzý 5
    }
}
