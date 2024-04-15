using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound; // Para el sonido de la bala
    public float Speed; // Velocidad de la bala

    private Rigidbody2D rb; // Referencia al Rigidbody2D de la bala
    private Vector2 Direction; // Dirección de la bala

    // Start se llama antes del primer frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el Rigidbody2D de la bala
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound); // Reproducimos el sonido de la bala
    }

    // Update se llama una vez por frame
    void Update()
    {
        rb.velocity = Direction * Speed; // Establecemos la velocidad de la bala
    }

    // Establece la dirección de la bala
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    // Destruye la bala
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    // Se llama cuando la bala entra en colisión con otro Collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag.Equals("Player")) {
            Destroy(this.gameObject);
            JhonMovement john = collision.GetComponent<JhonMovement>(); // Obtenemos el componente JhonMovement del objeto con el que colisionó la bala
            john.Hit(); // Llamamos al método Hit() del script JhonMovement
        }

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(this.gameObject);
            GruntScript grunt = collision.GetComponent<GruntScript>(); // Obtenemos el componente GruntScript del objeto con el que colisionó la bala
            grunt.Hit(); // Llamamos al método Hit() del script JhonMovement
        }
        
    }
}
