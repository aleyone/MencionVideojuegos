using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    GameObject enemy;
    private bool movimiento = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("moveEnemy", 0.7f, 0.7f);
    }

    // Update is called once per frame
    void moveEnemy()
    {
        if (movimiento==true)
        {
            transform.Translate(Vector3.right);
            if(transform.position.x > 6.3f)
            {
                Debug.Log("Has llegado el borde");
                movimiento = false;
            }
           
        } else if (movimiento==false)
        {
            transform.Translate(Vector3.left);
            if(transform.position.x < -6.3f)
            {
                Debug.Log("Aquí deberías ir a la izquierda.");
                movimiento = true;
            }
        }
    }

}
