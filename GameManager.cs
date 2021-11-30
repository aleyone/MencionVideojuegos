using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    string[] nombre = { "Escorpion", "Kano", "Sonya", "Subzero", "Johnny Cage" };
    string[] categoria = { "Ninja", "Mercenario", "Teniente", "Ninja", "Actor" };
    GameObject[] e;
    List<GameObject> Deaths = new List<GameObject>();
    Fighter luchador;

    public int aleatHealth()
    {
        int vida = (int)Random.Range(80, 100);
        return vida;
    }
    public void InitFighter(GameObject[] e)
    {
        
        for (int i = 0; i < e.Length; i++)
        {
            e[i].GetComponent<Fighter>().Name = nombre[i];
            e[i].GetComponent<Fighter>().Category = categoria[i];
            e[i].GetComponent<Fighter>().Health = aleatHealth();
        }
    }

    public GameObject maxLife(GameObject[] e) 
    {
        int maximo=0;
        GameObject max=e[0];
        for (int i=0; i< e.Length; i++)
        {
            Debug.Log("Entra " + e[i].GetComponent<Fighter>().Name + " al juego");
            if (e[i].GetComponent<Fighter>().Health >= maximo)
            {                
                maximo = e[i].GetComponent<Fighter>().Health;
                max = e[i];
                Debug.Log("Ahora el maximo es: " + max.GetComponent<Fighter>().Name + " con " + max.GetComponent<Fighter>().Health);
            }


        }
        

        return max;
    }

    public void addDeath(GameObject f)
    {
        Deaths.Add(f);
    }
    // Start is called before the first frame update
    void Start()
    {
        e = GameObject.FindGameObjectsWithTag("tagFighter");
        InitFighter(e);
        maxLife(e);
        luchador = new Fighter();
        Debug.Log("Vamos a matar a " + e[3].GetComponent<Fighter>().Name);
        e[3].GetComponent<Fighter>().Health = 0;
        
        Debug.Log("Recorremos lista Deaths");
        foreach (GameObject muerto in Deaths)
        {
            Debug.Log(muerto.GetComponent<Fighter>().Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i< e.Length; i++)
        {
            if (e[i].GetComponent<Fighter>().isAlive())
            {
                Deaths.Add(e[i]);
            }
        }
        
    }
}
