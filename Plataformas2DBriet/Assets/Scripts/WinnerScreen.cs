using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public AudioClip SoundWin; // Sonido de la victoria
    public AudioClip SoundClick; // Sonido del la derrota


    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "score: " + score.ToString();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundWin);

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void MenuButton()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundClick);
        SceneManager.LoadScene("MainMenu");
    }
}
