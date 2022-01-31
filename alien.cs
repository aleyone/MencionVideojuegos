using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    GameObject enemy;
    private bool movimiento = true;
    private float aceleracion = 0.5f;
    private float speedRepeat = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(speedRepeat);
        moveEnemy();
        StartCoroutine(Wait());
    }
    // Update is called once per frame
    void moveEnemy()
    {
        if (movimiento==true)
        {
            transform.Translate(Vector3.right*aceleracion);
            if(transform.position.x > 5.6f)
            {
                movimiento = false;
                transform.Translate(Vector3.down);


                if (speedRepeat >=0.2)
                {
                    transform.Translate(Vector3.down);
                    aceleracion += 0.2f;
                    speedRepeat -= 0.1f;
                }
                Debug.Log("Aceleracion: " + aceleracion);
                Debug.Log("Speed Repeat: " + speedRepeat);
            }
           
        } else if (movimiento==false)
        {
            transform.Translate(Vector3.left*aceleracion);
            if(transform.position.x < -5.6f)
            {
                movimiento = true;

                if (speedRepeat >=0.2)
                {
                    transform.Translate(Vector3.down);
                    aceleracion += 0.2f;
                    speedRepeat -= 0.1f;
                }
                Debug.Log("Aceleracion: " + aceleracion);
                Debug.Log("Speed Repeat: " + speedRepeat);
            }
        }
    }

}
