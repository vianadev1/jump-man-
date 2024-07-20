using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class idioma : MonoBehaviour
{
    public int cambioidioma = 1;
    public string[] textoIngles;
    public string[] textoespañol;
    public string[] textoesPortugues;
    public TextMeshProUGUI[] letreros;
    [Header("estado del idioma ")]
    public int estadoBoton;
    void Update()
    {
      //  cambiar(estadoBoton);
    }

   /** public void cambiar(int indx)
    {
        switch (indx)
        {

            case 1:
                idiomaingles();
                break;
            case 2:
                idiomaespañol();
                break;
            case 3:
                idiomaportugues();
                break;
        }

    
        if (cambioidioma == 0)
        {

        }
    }*/

    public void idiomaespañol()
    {
        if (letreros[0] != null)
        {
            for (int i = 0; i < letreros.Length; i++)
            {
                if (letreros[i] != null)
                {
                    letreros[i].text = textoespañol[i];
                }
            }
        }
    }
    public void idiomaingles()
    {
        if (letreros[0] != null)
        {
            for (int i = 0; i < letreros.Length; i++)
            {
                if (letreros[i] != null)
                {
                    letreros[i].text = textoIngles[i];
                }
            }
        }
    }
    public void idiomaportugues()
    {
        if (letreros[0] != null)
        {
            for (int i = 0; i < letreros.Length; i++)
            {
                if (letreros[i] != null)
                {
                    letreros[i].text = textoesPortugues[i];
                }
            }
        }
    }

    public void estadoidioma(int estado)
    {
        estadoBoton = estado;
        // esta funcion depende  del boton 
        // si 1 2  3 cambiar el arrai d elos idiomas  


    }

 }



