using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource eatSound;
    [SerializeField] private TextMeshProUGUI text; 

    private int points = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit") 
        {
            eatSound.Play();
            Destroy(collision.gameObject);
            points++;
            text.text = "Points: " + points; 
        }
    }
}
