using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    //Head[]
    public playServices logros; 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("level test 1"))
        {
            logros.nivel1();
        }
        if (collision.gameObject.CompareTag("level test 2"))
        {
            logros.nivel2();
        }
        if (collision.gameObject.CompareTag("level test 3"))
        {
            logros.nivel3();
        }
        if (collision.gameObject.CompareTag("level test 4"))
        {
            logros.nivel4();
        }
        if (collision.gameObject.CompareTag("level test 5"))
        {
            logros.nivel5();
        }
    }
}
