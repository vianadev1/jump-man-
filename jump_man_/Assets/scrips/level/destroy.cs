using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float tiempo = 0;
    public GameObject pefrab;


    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 6)
        {
            gameObject.SetActive(false);
            tiempo = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("base")) ; //usamos los tag para comparar objectos 
        {
            gameObject.SetActive(false);
            tiempo = 0;

        }
    }
}
