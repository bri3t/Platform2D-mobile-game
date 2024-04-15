using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    // Referencia al objeto de la bala
    public GameObject BulletPrefab;

    // Objeto que hace referencia a nosotros
    public GameObject John;

    // Variable para gestionar el tiempo entre disparos
    private float LastShoot;


    public int Health { get { return health; } }

    private int health = 2; // Vida del enemigo

    private Animator Animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private bool isHurting = false;

    private void Start()
    {
        Animator = GetComponent<Animator>(); // Obtenemos el componente Animator
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    // Update se llama una vez por frame
    void Update()
    {
        Animator.SetBool("dead", health == 0); // Establece el parámetro "dead" en el Animator

        if (John == null) return; // Si el objeto John es nulo, salimos de la función

        // Calculamos la dirección hacia John
        Vector3 direction = John.transform.position - transform.position;

        // Con esto aseguramos que el enemigo siempre esté apuntando hacia John
        if (direction.x > 0.0f)
            transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
        else
            transform.localScale = new Vector3(-5.0f, 5.0f, 1.0f);

        // Calculamos la distancia entre el enemigo y John
        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        // Si la distancia es menor a 5 y el tiempo entre disparos es correcto, el enemigo dispara
        if (distance < 5.0f && Time.time > LastShoot + 1.0f && GameManager.Instance.Vidas > 0 && health > 0)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    // Método para realizar el disparo
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 5.0f)
            direction = Vector2.right;
        else
            direction = Vector2.left;

        // Instanciamos la bala y establecemos su dirección
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    // Método para gestionar el impacto al enemigo
    public void Hit()
    {
        health = health - 1; // Reducimos la vida del enemigo
        if (!isHurting) StartCoroutine(ChangeColorTemporarily());

        if (health == 0)
        {
            StartCoroutine(animacionMorir()); // Iniciamos la animación de muerte
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

    public void IniciarAnimacionMorir()
    {
        StartCoroutine(animacionMorir());
    }


    // Corrutina para la animación de muerte
    IEnumerator animacionMorir()
    {
        health = 0;
        Animator.SetBool("dead", true); // Establecemos el parámetro "dead" en el Animator como verdadero
        yield return new WaitForSeconds(1.0f); // Esperamos un segundo
        Destroy(gameObject); // Destruimos el objeto del enemigo
        StopCoroutine("animacion"); // Detenemos la corutina
    }
}
