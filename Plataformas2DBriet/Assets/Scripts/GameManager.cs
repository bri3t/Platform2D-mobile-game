using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Para que otras clases hagan referencia a este gameManager
                                                             // Esto lo hago para que el prefab (coin por ejemplo) no se le tenga que indicar el gameManager
                                                             // manualmente cada vez que quiero crear una nueva instancia
    private void Awake()
    {
        if (Instance == null) // si esta vacia se le asigna la variable instance
        {
            Instance = this;
        }else // si no está vacia se avisara con un mensaje por consola
        {
            Debug.Log("Hay más de un Game Manager en escena!");
        }
    }

    public int PuntosTotales { get{ return puntosTotales; } } // Esto se hace para que la variable puntos totales sea visible por otras clases pero que no sea modificable des de la interfaz Unity
    private int puntosTotales; 

   
    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }
}
