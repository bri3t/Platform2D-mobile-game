using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JhonMovement : MonoBehaviour
{

    public GameObject BulletPrefab; // fa referencia a la bala
    public float Speed; // es la variable que controla la velocitat del jugador
    public float JumpForce; // controla la força de salt
    public AudioClip SoundJump; // per al soroll del salt
    public AudioClip SoundHit; // per al soroll al rebre bala

    // altres variables
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded; // indica si estamos en el suelo o no (true significa que estamos en el suelo)
    private float LastShoot; // guarda cuando se hizo el ultimo disparo
    private int Health = 4; // vida del personatge


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
        else if( Horizontal > 0.0f) transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        Animator.SetBool("running", Horizontal != 0.0f);



        Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
        {
            Grounded = true;
        }
        else Grounded= false;
        

        // executara la funcio de saltar si s'apreta la tecla per a fer-ho i el personatge esta tocant el terre
        if (Input.GetKeyDown(KeyCode.W) && Grounded)        
        {
            Jump();
        }


        // fara la funcio de disparar si s'apreta la tecla per a fer-ho i el temps entre dispars és correcte
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f) 
        {
            Shoot();
            LastShoot = Time.time;
        } 
    }


    private void Shoot() // funcio de disparar
    {
        Vector3 direction;
        if (transform.localScale.x == 5.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }


    private void Jump() // funcio per a saltar
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundJump);

    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y); 
    }

    public void Hit() // se llama esta funcion cuando recibe una bala
    {
        Health -= 1; // se le resta una vida

        GameManager.Instance.PerderVida();
        //HUD.Instance.DesactivarVida(Health); // llamamos a la funcion de desactivarVida de la clase HUD
        if (Health == 0) Destroy(gameObject); 
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundHit);

    }
}
