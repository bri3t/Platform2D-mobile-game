using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class Vida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.Vidas < 4) // Si en jugador se choca con la vida entonces...
        {
            GameManager.Instance.RecuperarVida(); // Se recupera una vida
            Destroy(this.gameObject); // se destruye la vida
        }
    }
}
