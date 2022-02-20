using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    SpriteRenderer PlayerSR;
    float fuerza=3;
    Animator run;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerSR = GetComponent<SpriteRenderer>();
        run = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float movimiento = Input.GetAxis("Horizontal");


        PlayerRB.velocity = (transform.right * movimiento * fuerza);
        run.SetFloat("MoveSpeed", Mathf.Abs(movimiento));
        if (movimiento >= 0)
        {            
            PlayerSR.flipX = false;
        } else
        {
            PlayerSR.flipX = true;            
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
