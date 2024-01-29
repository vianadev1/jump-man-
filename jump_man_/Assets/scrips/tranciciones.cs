using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tranciciones : MonoBehaviour
{
    /***public GameObject Cam1;             // intaciar las virtual camaras 
    public GameObject Cam2;             // 
    public GameObject Cam3 , Cam4, Cam5 ,Cam6,Cam7,Cam8,Cam9,Cam10,Cam11,Cam12,Cam13,Cam_14,Cam15,Cam16,Cam17,Cam18,Cam19,
        Cam20,Cam21,Cam22,Cam23;  **/
    public int c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14 = 0, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24= 0; 
    public  GameObject[] camaras;
    int[] toma;
   
    void Start()
    {
     // camaras = new GameObject[22];
        toma = new int[22];
       //for (int i = 0; i < 22; i++)  
            
           // camaras[i] =  + i;
    }
    void Update()
    {

        for (int i = 0; i < 22; i++)
        { 
            if (toma[i] == 1 )
            {
                 camaras[i].gameObject.SetActive(true);
                  toma[i] = 0;

            }
            else
            {
                camaras[i].gameObject.SetActive(false);

            }

          /**(toma[i-1] == 1  &&  toma[i] == 1  ) // subir nivel
            {
                camaras[-i].gameObject.SetActive(false);
                toma[i - 1] = 0;
 
            }***///
           
        }
       /*** if (c23 == 1 && Cam23.gameObject.activeInHierarchy == false)
        {
            Cam23.gameObject.SetActive(true);
            Debug.Log("wacchpp");
            c23 = 0;
        }**///
    } 
    private void OnTriggerEnter2D(Collider2D enemigo)
    {

        Debug.Log("tocado");

        if (enemigo.CompareTag("nivel1")) //usamos los tag para comparar objectos 
        {
            Debug.Log("nivel1");
            c1 = 1;
            toma[0] = 1;
        }

        if (enemigo.CompareTag("nivel2"))
        {
            c2 = 1;
            toma[1] = 1;
        }
        if (enemigo.CompareTag("nivel3"))
        {
            c3 = 1;
            toma[2] = 1;
        }
        if (enemigo.CompareTag("nivel4"))
        {
            c4 = 1;
            toma[3] = 1;
        }
        if (enemigo.CompareTag("nivel5"))
        {
            c5 = 1;
            toma[4] = 1;
        }
        if (enemigo.CompareTag("nivel6"))
        {
            c6 = 1;
            toma[5] = 1;
        }
        if (enemigo.CompareTag("nivel7"))
        {
            c7 = 1;
            toma[6] = 1;
        }
        if (enemigo.CompareTag("nivel8"))
        {
            c8 = 1;
            toma[7] = 1;
        }
        if (enemigo.CompareTag("nivel9"))
        {
            c9 = 1;
            toma[8] = 1;
        }
        if (enemigo.CompareTag("nivel10"))
        {
            c10 = 1;
            toma[9] = 1;
        }
        if (enemigo.CompareTag("nivel11"))
        {
            c11 = 1;
            toma[10] = 1;
        }
        if (enemigo.CompareTag("nivel12"))
        {
            c12 = 1;
            toma[11] = 1;
        }
        if (enemigo.CompareTag("nivel13"))
        {
            c13 = 1;
            toma[12] = 1;
        }
        if (enemigo.CompareTag("nivel14"))
        {
            c14 = 1;
            toma[13] = 1;
        }
        if (enemigo.CompareTag("nivel15"))
        {
            c15 = 1;
            toma[14] = 1;
        }
        if (enemigo.CompareTag("nivel16"))
        {
            toma[15] = 1;
            c16 = 1;
        }
        if (enemigo.CompareTag("nivel17"))
        {
            c17 = 1;
            toma[16] = 1;
        }
        if (enemigo.CompareTag("nivel18"))
        {
            toma[17] = 1;
            c18 = 1;
        }
        if (enemigo.CompareTag("nivel19"))
        {
            toma[18] = 1;
            c19 = 1;
        }
        if (enemigo.CompareTag("nivel20"))
        {
            toma[19] = 1;
            c20 = 1;
        }
      
        if (enemigo.CompareTag("nivel22"))
        {
            toma[20] = 1;
            c22 = 1;
        }
        if (enemigo.CompareTag("nivel23"))
        {
            toma[21] = 1;
            c23 = 1;
        }
       
    
        
    }
}
