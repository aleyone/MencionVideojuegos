using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public float force;
    public int speedFire;
    Rigidbody2D MyRB;
    public GameObject torpedo;
    GameObject bala;
    public bool canShot = true;
    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody2D>();
    }

 
    void FixedUpdate()
    {
        // Restringir movimiento -6.7 / +6.7
        float movement = Input.GetAxis("Horizontal");

        MyRB.velocity = (transform.right * movement * force);

        //Restringir
        // Now compute the Clamp value.
        float xPos = Mathf.Clamp(MyRB.position.x, -6.4f, 6.4f);

        // Update the position of the cube.
        transform.position = new Vector2(xPos, MyRB.position.y);

        if (Input.GetButton("Jump") && canShot)
        {
                bala = Instantiate(torpedo, new Vector2(MyRB.position.x, -5.8f), Quaternion.identity);
                Rigidbody2D clone = bala.GetComponent<Rigidbody2D>();
                clone.velocity = new Vector2(0f, 1f) * speedFire;
                canShot = false;
            }
        }  



    private void OnTriggerEnter2D(Collider2D other)
    {
        canShot = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       Destroy(bala);
    }

    public void canShot_()
    {
        canShot = true;
    }


}
