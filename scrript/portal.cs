using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public string nextLevelName; // Nama level berikutnya

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevelName); // Memuat level berikutnya
        }
    }
}
