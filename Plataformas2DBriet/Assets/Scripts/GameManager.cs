using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Para que otras clases hagan referencia a este GameManager

    public int Vidas { get { return vidas; } } // Variable para almacenar el n�mero de vidas

    private int vidas = 4; // Inicializamos el n�mero de vidas en 4 al inicio del juego

    public int PuntosTotales { get { return puntosTotales; } } // Variable para almacenar los puntos totales

    private int puntosTotales; // Inicializamos los puntos totales en 0 al inicio del juego
    public int metaPuntos;

    public HUD hud; // Referencia al HUD para actualizar la interfaz de usuario

    public JhonMovement john = JhonMovement.Instance; // Referencia la clase john

    public GameOverScreen GameOverScreen;
    public WinnerScreen WinnerScreen;

    private void Awake()
    {
        if (Instance == null) // Si no hay una instancia previa de GameManager, se asigna la instancia actual
        {
            Instance = this;
        }
        else // Si ya existe una instancia previa, se muestra un mensaje de advertencia en la consola
        {
            Debug.Log("�Hay m�s de un Game Manager en la escena!");
        }
    }

   

    // M�todo para sumar puntos al contador de puntos totales
    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
        hud.ActualizarPuntos(puntosTotales); // Actualizamos el contador de puntos en la interfaz de usuario
        if (puntosTotales >= metaPuntos)
        {
            Debug.Log("win");
            WinnerScreen.SetUp(puntosTotales);
        }
    }

    // M�todo para restar una vida
    public void PerderVida()
    {
        vidas -= 1; // Restamos una vida
        hud.DesactivarVida(vidas); // Desactivamos la representaci�n gr�fica de una vida en la interfaz de usuario
        Debug.Log(vidas);

        if (vidas == 0)
        {
            john.Morir(); // Si el n�mero de vidas llega a 0, Jhon muere
            //SceneManager.LoadScene(0);
            Debug.Log("morir");
            GameOverScreen.SetUp(puntosTotales);
        }
    }

    // M�todo para recuperar una vida
    public void RecuperarVida()
    {
        if (vidas == 4) // Si ya tenemos 4 vidas, no se puede recuperar m�s
        {
            return;
        }
        hud.ActivarVida(vidas); // Activamos la representaci�n gr�fica de una vida en la interfaz de usuario
        vidas += 1; // Aumentamos en 1 el n�mero de vidas
    }
}
