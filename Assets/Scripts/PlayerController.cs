using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    float fuerza=5;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float movimiento = Input.GetAxis("Horizontal");
        PlayerRB.velocity = (transform.right * movimiento * fuerza);
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
