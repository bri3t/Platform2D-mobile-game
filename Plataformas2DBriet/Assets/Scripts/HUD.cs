using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameManager gameManager; // Para acceder al gameManager
    public TextMeshProUGUI puntos; // texto puntos

   
    // Update is called once per frame
    void Update()
    {
        puntos.text = gameManager.PuntosTotales.ToString(); // se actualizan los puntos segun los que indica el gameManager
    }

    public void ActualizarPuntos(int puntosTotales)
    {

    }
}
