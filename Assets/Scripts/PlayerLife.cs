using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Die()
    {
        anim.SetTrigger("Dead");
        rb.bodyType = RigidbodyType2D.Static;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {

            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Void")
        {
            Die();
        }
    }

}
