using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; // Importa el espacio de nombres Unity.VisualScripting
using UnityEngine; // Importa el espacio de nombres UnityEngine

public class JhonMovement : MonoBehaviour // Declara la clase JhonMovement que hereda de MonoBehaviour
{

    public GameObject BulletPrefab; // Referencia al prefab de la bala
    public float Speed; // Velocidad del jugador
    public float JumpForce; // Fuerza del salto
    public AudioClip SoundJump; // Sonido del salto
    public AudioClip SoundHit; // Sonido al recibir un disparo
    private CameraScript cameraScript;

    private Rigidbody2D Rigidbody2D; // Referencia al Rigidbody2D del objeto
    private Animator Animator; // Referencia al Animator del objeto
    private float Horizontal; // Almacena el valor del eje horizontal
    private bool Grounded; // Indica si estamos en el suelo o no (true significa que estamos en el suelo)
    private float LastShoot; // Guarda cuando se hizo el último disparo
    public bool IsOnTop { get { return isOnTop; } }

    private bool isOnTop = false;

    public static JhonMovement Instance { get; private set; } // Instancia estática de la clase JhonMovement

    // Start is called before the first frame update
    void Start() // Método llamado al inicio del juego
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del objeto
        Animator = GetComponent<Animator>(); // Obtiene el Animator del objeto
    }

    // Update is called once per frame
    void Update() // Método llamado en cada frame
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); // Obtiene la entrada del eje horizontal

        // Cambia la escala del objeto según la dirección horizontal
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-5.0f, 5.0f, 5.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);

        // Establece el parámetro "running" en el Animator según la dirección horizontal
        Animator.SetBool("running", Horizontal != 0.0f);
        // Establece el parámetro "dead" en el Animator según las vidas del GameManager
        Animator.SetBool("dead", GameManager.Instance.Vidas == 0);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f)) // Realiza un Raycast hacia abajo
        {
            Grounded = true; // Establece Grounded a true si el Raycast golpea algo
        }
        else Grounded = false; // Establece Grounded a false si el Raycast no golpea nada

        // Ejecuta la función de saltar si se presiona la tecla correspondiente y el personaje está tocando el suelo
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        // Ejecuta la función de disparar si se presiona la tecla correspondiente y el tiempo entre disparos es correcto
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.15f)
        {
            Shoot();
            LastShoot = Time.time; // Actualiza el tiempo del último disparo
        }

        if (this.transform.position.y <= 4.8f) isOnTop = false; // si jhon esta por debajo de 4.8 del valor de Y significara que no esta en la parte superior del mapa
                                                                // Entonces la camara se posicionara donde toca correctamente
    }

    // Función para disparar
    private void Shoot()
    {
        Vector3 direction; // Dirección del disparo
        if (transform.localScale.x == 5.0f) direction = Vector2.right; // Determina la dirección según la escala del objeto
        else direction = Vector2.left;

        // Instancia una bala en la posición del objeto con la dirección adecuada
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction); // Establece la dirección de la bala
    }

    // Función para saltar
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce); // Aplica una fuerza hacia arriba al Rigidbody2D
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundJump); // Reproduce el sonido del salto
    }

    // Método llamado en cada frame fijo para el movimiento del jugador
    private void FixedUpdate()
    {
        // Verifica si Jhon todavía tiene vidas
        if (GameManager.Instance.Vidas > 0 && GameManager.Instance.PuntosTotales < 15)
        {
            // Si Jhon tiene vidas, actualiza la velocidad
            Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        }
        else
        {
            // Si Jhon no tiene vidas, establece la velocidad a cero para bloquear su movimiento
            Rigidbody2D.velocity = Vector2.zero;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coinBorder"))
        {
            isOnTop = true;        
        }

    }

    



    // Función llamada cuando el jugador recibe un disparo
    public void Hit()
    {
        GameManager.Instance.PerderVida(); // Reduce las vidas del GameManager
        // Desactiva una vida en la interfaz de usuario (comentado)
        // Destruye el objeto si no tiene más vidas (comentado)
        // Reproduce el sonido al recibir un disparo (comentado)
    }

    // Función llamada para la animación de muerte del jugador
    public void Morir()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundHit); // Reproduce el sonido al morir
        StartCoroutine(animacion()); // Inicia la animación de muerte
    }

    // Corrutina para la animación de muerte
    IEnumerator animacion()
    {
        Animator.SetBool("dead", true); // Establece el parámetro "dead" en el Animator como verdadero
        yield return new WaitForSeconds(1.0f); // Espera un segundo
        //Destroy(gameObject); // Destruye el objeto del jugador
        StopCoroutine("animacion"); // Detiene la corutina
    }
}
