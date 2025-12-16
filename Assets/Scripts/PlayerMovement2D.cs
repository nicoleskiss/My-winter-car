using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D rb; //Deklarerar en Rigidbody-variabel
    private SpriteRenderer sprite; //Deklarerar en Rigidbody-variabel
    private Animator anim; //Deklarerar en Animator-variabel
    [SerializeField] private AudioSource jumpSound; 
    [SerializeField] private float speed = 5f; //Deklarerar en float som ska styra spelarens hastighet
    // SerializeField gör att variabeln går att ändra från editorn
    [SerializeField] private float jumpHeight = 10f; //Deklarerar en float som ska styra spelarens hastighet

    private float horizontalInput; //En variabel som lagrar åt vilket håll användaren trycker (-1 är vänster, 1 är höger)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Hämtar Rigidbody-komponenten på spelobjektet och lagrar i rb
        sprite = GetComponent<SpriteRenderer>(); //Hämtar Sprite-komponenten på spelobjektet och lagrar i sprite
        anim = GetComponent<Animator>(); //Hämtar Animator-komponenten på spelobjektet och lagrar i anim
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //Lyssnar efter om användaren trycker till höger eller till vänster och sparar i horizontalInput
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y); //Sätter en hastighet på rigidbodyn på spelaren

        //Om användaren rör sig till vänster - Vänd spelarens sprite och spela "springanimationen"
        anim.SetBool("Running", false);
        anim.SetBool("Jumping", false);
        anim.SetBool("Falling", false);
        anim.SetBool("Hit", false);


        if (rb.linearVelocity.x < 0)
        {
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }

        if (rb.linearVelocity.x > 0)
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }

        if (rb.linearVelocity.y > 0.1f)
        {
            anim.SetBool("Jumping", true);
        }

        if (rb.linearVelocity.y < -0.1f)
        {
            anim.SetBool("Falling", true);
        }

        //Om användaren trycker space - Hoppa
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
        }

    }
}
