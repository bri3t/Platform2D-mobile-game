using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Jhon;


    // Update is called once per frame
    void Update()
    {
        if (Jhon != null)
        {
            Vector3 position = transform.position;
            position.x = Jhon.transform.position.x;
            position.y = 0;
            if (Jhon.transform.position.y >= 4.8f) position.y = Jhon.transform.position.y;
            
            transform.position = position;
        }

    }
}
