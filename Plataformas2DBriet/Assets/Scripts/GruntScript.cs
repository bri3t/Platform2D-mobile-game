using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    // fa referencia al objecte de la bala
    public GameObject BulletPrefab;

    // objecte que fa referencia a nosaltres
    public GameObject John;

    // variable per gestionar el temps entre dispars
    private float LastShoot;

    private int Health = 3; // vida del enemic

    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Animator.SetBool("dead", Health == 0);

        if (John == null) return;
        // nomes seguira el codi si el personatge está viu, és a dir, que no es null

        Vector3 direction = John.transform.position - transform.position;

        // amb aixo el que farem serà que el enemic sempre estigui apuntant-nos a nosaltres
        if (direction.x > 0.0f) transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
        else transform.localScale = new Vector3(-5.0f, 5.0f, 1.0f);


        // calculem la distancia en valor absolut que hi ha entre el enemic i jo
        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        // si la distancia es menor a 5 i el temps entre dispars és correcte, farem que l'enemic dispari
        if (distance < 5.0f && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }


    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 5.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            StartCoroutine(animacion());
        }
    }

    IEnumerator animacion()
    {
        Animator.SetBool("dead", true);
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
        StopCoroutine("animacion");
    }
}
