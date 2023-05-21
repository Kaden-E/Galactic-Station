using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the main menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }
}