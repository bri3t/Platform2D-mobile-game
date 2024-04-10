using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Esto se hace para que la variable puntos totales sea visible por otras clases pero que no sea modificable des de la interfaz Unity
    public int PuntosTotales { get{ return puntosTotales; } } 
    private int puntosTotales; 

   
    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }
}
