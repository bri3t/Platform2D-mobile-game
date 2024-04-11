using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos; // texto puntos

    public GameObject[] vidas;

    public static HUD Instance { get; private set; } // Para que otras clases hagan referencia a este gameManager


  

    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString() + " / " + GameManager.Instance.metaPuntos; // Se le asigna al texto de los puntos el valor que le entra por parametro
    }

    public void DesactivarVida(int indiceVida)
    {
        vidas[indiceVida].SetActive(false);
    }

    public void ActivarVida(int indiceVida)
    {
        vidas[indiceVida].SetActive(true);
    }
}
