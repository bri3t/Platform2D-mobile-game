using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JhonMovement : MonoBehaviour
{

    public GameObject BulletPrefab; // Referencia al prefab de la bala
    public float Speed; // Velocidad del jugador
    public float JumpForce; // Fuerza del salto
    public AudioClip SoundJump; // Sonido del salto
    public AudioClip SoundHit; // Sonido al recibir un disparo

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded; // Indica si estamos en el suelo o no (true significa que estamos en el suelo)
    private float LastShoot; // Guarda cuando se hizo el último disparo

    public static JhonMovement Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-5.0f, 5.0f, 5.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        Animator.SetBool("running", Horizontal != 0.0f);
        Animator.SetBool("dead", GameManager.Instance.Vidas == 0); // Establece el parámetro "dead" en el Animator

        Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Ejecutará la función de saltar si se presiona la tecla correspondiente y el personaje está tocando el suelo
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        // Realizará la función de disparar si se presiona la tecla correspondiente y el tiempo entre disparos es correcto
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.15f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }


    private void Shoot() // Función de disparar
    {
        Vector3 direction;
        if (transform.localScale.x == 5.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }


    private void Jump() // Función para saltar
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundJump);
    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    public void Hit() // Se llama a esta función cuando recibe una bala
    {
        GameManager.Instance.PerderVida();
        //HUD.Instance.DesactivarVida(Health); // Llamamos a la función de desactivarVida de la clase HUD
        //if (Health == 0) Destroy(gameObject); 
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundHit);
    }

    public void Morir()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundHit);
        StartCoroutine(animacion()); // Iniciamos la animación de muerte
    }

    // Corrutina para la animación de muerte
    IEnumerator animacion()
    {
        Animator.SetBool("dead", true); // Establecemos el parámetro "dead" en el Animator como verdadero
        yield return new WaitForSeconds(1.0f); // Esperamos un segundo
        Destroy(gameObject); // Destruimos el objeto del enemigo
        StopCoroutine("animacion"); // Detenemos la corutina
    }
}
