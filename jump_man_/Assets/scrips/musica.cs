using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica : MonoBehaviour
{
    public GameObject n1, n2, n3, n4, n5;
    float c1;
    public GameObject player;
    public GameObject ece1, ece2, ece3, ece4, ece5;

    //c29, c30, c31, c32, c33, c34, c35, c36 ;
    // public GameObject golpesounds;
    void Update()
    {
        c1 = player.transform.position.y;
         
        ///////////nivel uno 
         if (c1 <= 158 ) 
         {
             n1.SetActive(true);
             ece1.SetActive(true);
             ece2.SetActive(true);
             ece3.SetActive(false);
             ece4.SetActive(false);
             ece5.SetActive(false);

        }
         else
         {
             n1.SetActive(false);
         }
         ////nivel 2
        if (c1 >= 158  && c1 <=297 )
        {
            n2.SetActive(true);
            ece1.SetActive(true);
            ece2.SetActive(true);
            ece3.SetActive(true);
            ece4.SetActive(false);
            ece5.SetActive(false);
        }
        else
        {
            n2.SetActive(false);
        }
        ////nivel 3
        if (c1 >= 297 && c1 <= 481)
        {
            n3.SetActive(true); // musica 
            ece1.SetActive(false);
            ece2.SetActive(true);
            ece3.SetActive(true);
            ece4.SetActive(true);
            ece5.SetActive(false);
        }
        else
        {
            n3.SetActive(false);
        }
        ////nivel 4 
        if (c1 >= 481 && c1 <=576 )
        {
            n4.SetActive(true);
            ece1.SetActive(false);
            ece2.SetActive(false);
            ece3.SetActive(true);
            ece4.SetActive(true);
            ece5.SetActive(true);
        }
        else
        {
            n4.SetActive(false);
        }

        if (c1 >= 576 && c1 <= 723)
        {
            n5.SetActive(true);
            ece1.SetActive(false);
            ece2.SetActive(false);
            ece3.SetActive(false);
            ece4.SetActive(true);
            ece5.SetActive(true);
        }
        else
        {
            n5.SetActive(false);
        }
    }
    

}
