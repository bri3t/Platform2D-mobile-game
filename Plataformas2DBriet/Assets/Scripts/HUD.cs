using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos; // texto puntos

   
    // Update is called once per frame
    void Update()
    {
        puntos.text = GameManager.Instance.PuntosTotales.ToString(); // se actualizan los puntos segun los que indica el gameManager
    }

    public void ActualizarPuntos(int puntosTotales)
    {

    }
}
