using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efecsound : MonoBehaviour
{
    public GameObject golpesounds;
    int sons = 0;

    // Update is called once per frame

     void Start()
    {
        
    }
    void Update()
    {
        if (sons == 1 )
        {
            Debug.Log("chupa el orto");
            golpesounds.SetActive(true);
            sons = 0;
            

        }
       
    }
    private void OnTriggerEnter2D(Collider2D sonido)
    {
        if (sonido. CompareTag ("piso")) //usamos los tag para comparar objectos 
        {
            sons = 1;
            Debug.Log("chupame la pija ");
           
        }
    }
    

    
}
