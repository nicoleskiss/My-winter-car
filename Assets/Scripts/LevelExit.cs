using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private AudioSource exitAudio;
    [SerializeField] private string nextSceneName;

    private void Start()
    {
        exitAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
            exitAudio.Play();
        }
    }
}
