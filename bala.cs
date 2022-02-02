using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    GameObject nave;
    SpaceShipScript scriptnave;
    // Start is called before the first frame update
    void Start()
    {
        nave = GameObject.FindWithTag("nave");
        scriptnave = nave.GetComponent<SpaceShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        scriptnave.canShot_();
        Destroy(gameObject);

        if (other.gameObject.tag == "alien")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
