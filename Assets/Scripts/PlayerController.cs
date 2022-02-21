using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    SpriteRenderer PlayerSR;
    float fuerza=3;
    Animator anim;
    public float jumpForce;
    bool isGrounded=true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerSR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;
    }

    private void FixedUpdate()
    {
        float movimiento = Input.GetAxis("Horizontal");
        anim.SetFloat("VerticalVelocity", PlayerRB.velocity.y);
        Debug.Log("Velocidad en y " + PlayerRB.velocity.y);

        if (Input.GetAxis("Jump") > 0 && isGrounded==true)

        {
            Debug.Log("salto");
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, 0);
            PlayerRB.AddForce(new Vector2(0, jumpForce));
            //PlayerRB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            isGrounded = false;
            anim.SetBool("isGrounded", false);


        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider != null && isGrounded==false && PlayerRB.velocity.y <0)
        {
            if(hit.distance < 0.5)
            {
                Debug.Log("Detecto " + hit.collider.gameObject.name + "a distancia" + hit.distance);
                isGrounded = true;
                anim.SetBool("isGrounded", true);
            }
        }
    





    PlayerRB.velocity = (transform.right * movimiento * fuerza);
        anim.SetFloat("MoveSpeed", Mathf.Abs(movimiento));
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
