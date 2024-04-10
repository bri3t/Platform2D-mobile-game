using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public AudioClip Sound; // per al soroll de la bala

    public float Speed;

    private Rigidbody2D rb;
    private Vector2 Direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JhonMovement john = collision.GetComponent<JhonMovement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();

        // si es xoca amb jhon:
        if (john != null)
        {
            john.Hit();
        }

        // si es xoca amb l'enemic
        if (grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet(); // destrueix la bala
    }

}
