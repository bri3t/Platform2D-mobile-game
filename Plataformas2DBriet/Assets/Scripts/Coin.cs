using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1; // Puntos que sumara la moneda al recogerla
    public AudioClip SoundCoin; // Sonido moneda



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SumarPuntos(valor); // suma el valor (1) al gameManager
            Destroy(this.gameObject); // destruye la moneda
            Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundCoin);

        }
    }
}
