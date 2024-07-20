using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aire : MonoBehaviour
{
    public GameObject rigth; //son dos game objectos que fuerza a la  tiene efectos hacia la derche y izquierda 
    public GameObject left;
    public float tiempo = 0;
    Material mt;
    public Vector2 offset;
    public int derecha;
    public int izq;
    public int stop;
    public int secuencia;



    // Update is called once per frame
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;
        offset = mt.mainTextureOffset;
       
    }

    void Update()
    {
       
        tiempo += Time.deltaTime;

        if (tiempo <=  derecha  )            // izquierda
        { 
            rigth.SetActive(false);
            left.SetActive(true); 
            offset.x += Time.deltaTime;
            mt.mainTextureOffset = offset;  //mover el material 
        }
        if (tiempo > derecha  && tiempo <  stop  ) //stop   
        {
            rigth.SetActive(false);
            left.SetActive(false);
            offset.x = 0;
        }
        if (tiempo > stop   && tiempo < izq)
        {
            rigth.SetActive(true);
            left.SetActive(false);
            offset.x -= Time.deltaTime;
            mt.mainTextureOffset = offset;  //mover el material 
            
        }
        if (tiempo >= secuencia)
        {
            rigth.SetActive(false);
            left.SetActive(false);
            offset.x = 0;
        }

        if (tiempo > secuencia +1) // reseta el patron
        {
            tiempo = 0;
        }

    }
}
