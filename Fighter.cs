using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public string Name;
    public string Category;
    public int Health;
       
    public void DecreaseHealth(int masVida)
    {
        Health -= masVida;
    }

    public bool isAlive()
    {
        bool alive = true;
        if (Health == 0)
        {
            alive = false;
        }

        return alive;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
