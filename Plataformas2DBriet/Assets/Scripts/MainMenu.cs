using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public AudioClip SoundClick; // Sonido del la derrota
    public void ExitButton()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }

    public void StartGame()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundClick);
        SceneManager.LoadScene("Game");
    }
}
