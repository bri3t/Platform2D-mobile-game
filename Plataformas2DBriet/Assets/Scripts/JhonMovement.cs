using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; // Importa el espacio de nombres Unity.VisualScripting
using UnityEngine; // Importa el espacio de nombres UnityEngine

public class JhonMovement : MonoBehaviour // Declara la clase JhonMovement que hereda de MonoBehaviour
{

    public GameObject BulletPrefab; // Referencia al prefab de la bala
    public float JumpForce; // Fuerza del salto
    public AudioClip SoundJump; // Sonido del salto
    public AudioClip SoundHit; // Sonido al recibir un disparo

    public float speed; // Velocidad del jugador
    private float movimientoHorizontal = 0f; // Almacena el valor del eje movimientoHorizontal
    private Rigidbody2D rb2d; // Referencia al rb2d del objeto
    private Vector3 velocidad = Vector3.zero;
    private InputSystem inputSystem; // para el input System

    private Animator Animator; // Referencia al Animator del objeto
    private bool Grounded; // Indica si estamos en el suelo o no (true significa que estamos en el suelo)
    private float LastShoot; // Guarda cuando se hizo el último disparo
    public bool IsOnTop { get { return isOnTop; } }
    private bool isOnTop = false;

    public SpriteRenderer spriteRenderer;
    private bool isHurting = false;

    public static JhonMovement Instance { get; private set; } // Instancia estática de la clase JhonMovement




    // Start is called before the first frame update
    void Start() // Método llamado al inicio del juego
    {
        rb2d = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del objeto
        Animator = GetComponent<Animator>(); // Obtiene el Animator del objeto
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }


    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
    }

    private void OnDisable()
    {
        inputSystem.Disable();
    }


    // Update is called once per frame
    void Update() // Método llamado en cada frame
    {
        movimientoHorizontal = inputSystem.Movimiento.Horizontal.ReadValue<float>() * speed; // Obtiene la entrada del eje movimientoHorizontal

        // Cambia la escala del objeto según la dirección movimientoHorizontal
        if (movimientoHorizontal < 0.0f) transform.localScale = new Vector3(-5.0f, 5.0f, 5.0f);
        else if (movimientoHorizontal > 0.0f) transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);

        // Establece el parámetro "running" en el Animator según la dirección movimientoHorizontal
        Animator.SetBool("running", movimientoHorizontal != 0.0f);
        // Establece el parámetro "dead" en el Animator según las vidas del GameManager
        Animator.SetBool("dead", GameManager.Instance.Vidas == 0);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f)) // Realiza un Raycast hacia abajo
        {
            Grounded = true; // Establece Grounded a true si el Raycast golpea algo
        }
        else Grounded = false; // Establece Grounded a false si el Raycast no golpea nada





        // -------------------------------- Para teclado y raton (pruebas) --------------------------------
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
        // -------------------------------- Para teclado y raton (pruebas) --------------------------------



        if (this.transform.position.y <= 4.8f) isOnTop = false; // si jhon esta por debajo de 4.8 del valor de Y significara que no esta en la parte superior del mapa
                                                                // Entonces la camara se posicionara donde toca correctamente
    }

    // Método llamado en cada frame fijo para el movimiento del jugador
    private void FixedUpdate()
    {
        // Verifica si Jhon todavía tiene vidas
        if (GameManager.Instance.Vidas > 0 && GameManager.Instance.PuntosTotales < 15)
        {
            // Si Jhon tiene vidas, actualiza la velocidad
            Mover(movimientoHorizontal * Time.fixedDeltaTime);
        }
        else
        {
            // Si Jhon no tiene vidas, establece la velocidad a cero para bloquear su movimiento
            rb2d.velocity = Vector2.zero;
        }
    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjeto = new Vector2(mover, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velocidadObjeto, ref velocidad, 0f);
    }


    // Función para disparar
    public void Shoot()
    {
        if (Time.time > LastShoot + 0.15f)
        {     
            Vector3 direction; // Dirección del disparo
            if (transform.localScale.x == 5.0f) direction = Vector2.right; // Determina la dirección según la escala del objeto
            else direction = Vector2.left;

            // Instancia una bala en la posición del objeto con la dirección adecuada
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction); // Establece la dirección de la bala

            LastShoot = Time.time; // Actualiza el tiempo del último disparo

        }
    }

    // Función para saltar
    public void Jump()
    {
        if (Grounded)
        {
            rb2d.AddForce(Vector2.up * JumpForce); // Aplica una fuerza hacia arriba al Rigidbody2D
            Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundJump); // Reproduce el sonido del salto
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Cabeza"))
        {
            Grounded = true;
            Debug.Log("wtf");
            //GruntScript grunt = collision.gameObject.GetComponent<GruntScript>(); // Obtenemos el componente GruntScript del objeto con el que colisionó la bala
            //grunt.StartCoroutine(animacion()); // Iniciamos la animación de muerte
        }


        //if (collision.gameobject.comparetag("enemy"))
        //{
        //    hit();
        //}



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coinBorder"))
        {
            isOnTop = true;        
        }


    }

    IEnumerator ChangeColorTemporarily()
    {
        isHurting = true;
        Color originalColor = spriteRenderer.color; // Guarda el color original
        Color targetColor = Color.red; // Define el color a cambiar

        // Cambia al color rojo durante un breve periodo
        float timeToChange = 0.1f; // Tiempo para cambiar al color rojo
        for (float t = 0; t < 1; t += Time.deltaTime / timeToChange)
        {
            spriteRenderer.color = Color.Lerp(originalColor, targetColor, t);
            yield return null;
        }

        spriteRenderer.color = targetColor; // Asegúrate de que el color es completamente rojo

        // Espera 1 segundo
        yield return new WaitForSeconds(1);

        // Vuelve al color original
        timeToChange = 0.1f; // Tiempo para volver al color original
        for (float t = 0; t < 1; t += Time.deltaTime / timeToChange)
        {
            spriteRenderer.color = Color.Lerp(targetColor, originalColor, t);
            yield return null;
        }

        spriteRenderer.color = originalColor; // Restablece el color original
        isHurting = false;
    }

    // Función llamada cuando el jugador recibe un disparo
    public void Hit()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundHit); // Reproduce el sonido al morir
        if (!isHurting) StartCoroutine(ChangeColorTemporarily());
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
