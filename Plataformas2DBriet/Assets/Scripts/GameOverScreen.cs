using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public AudioClip SoundLost; // Sonido del la derrota
    public AudioClip SoundClick; // Sonido del la derrota


    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "score: " + score.ToString();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundLost);

    }

    public void RestartButton()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundClick);
        SceneManager.LoadScene("Game");
    }

    public void MenuButton()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundClick);
        SceneManager.LoadScene("MainMenu");
    }
}
