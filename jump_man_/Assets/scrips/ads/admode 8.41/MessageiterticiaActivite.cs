using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageiterticiaActivite : MonoBehaviour
{
    private float tiempo;
    public TextMeshProUGUI texto;
    public string mensaje;
    [Header("cuenta regresiva")]
    public TextMeshProUGUI textoContador;
    private int contador;
    private float tiempo_contador;
    [Header("anucios ")]
    public adsMasterAbmode ads;
    public int _cantidad_caidas_ads;
    public GameObject banner_de_contar;
    [Header("idiomas de letreos")]
    public idioma dataIDIOMA;
    public int estadoIdioma;
    public string[] wordlSspanhis;
    public string[] wordlingles;
    public string[] wordlSportugues;


    private void Start()
    {
        
       
        IniciarContador();
        ads.LoadInterstitalAd();
    }
    void Update()
    {
        estadoIdioma = dataIDIOMA.estadoBoton;
        tiempo += Time.deltaTime;
        tiempo_contador -= Time.deltaTime;
        texto.text = mensaje.ToString();
        contador = Mathf.RoundToInt(tiempo_contador);
        if (_cantidad_caidas_ads >= 1)
        {
            banner_de_contar.SetActive(true);

            if (tiempo >= 3 && _cantidad_caidas_ads >= 1)
            {
               
                ads.ShowInterstitalAd();
                _cantidad_caidas_ads = 0;
                tiempo = 0;
                gameObject.SetActive(false);
            }
        }
        else
        {
            banner_de_contar.SetActive(false);
        }

        if (tiempo >= 3)
        {
            _cantidad_caidas_ads += 1;

            tiempo = 0;
            tiempo_contador = 3;
            ads.LoadInterstitalAd();
            scripStart();
            gameObject.SetActive(false);
        }
        /**
        if (contador < -1)
        {
            // mostrar anucio 
            ads.ShowInterstitalAd();
        }**/
        ActualizarTextoContador();
    }
    private void ramdomfrase()
    {
        int Nun = Random.Range(1, 6);
        switch (Nun)
        {
            case 1:
                selecIdioamFrase(0);
                // mensaje = "champions don't give up";
                Debug.Log("1");
                break;
            case 2:
                selecIdioamFrase(1);
                // mensaje = "go away you are a loser";
                Debug.Log("2");
                break;
            case 3:
                selecIdioamFrase(2);
                Debug.Log("3");
                //mensaje = "jajajaajaj loser ";
                break;
            case 4:
                selecIdioamFrase(3);
                Debug.Log("4");
                //mensaje = "you could do it better";
                break;
            case 5:
                selecIdioamFrase(4);
                Debug.Log("5");
                //mensaje = "let's go to the top";
                break;
        }
    }
    private void IniciarContador()
    {
        contador = 3;
    }
    private void DecrementarContador()
    {
        contador--;
    }
    private void ActualizarTextoContador()
    {
        textoContador.text = contador.ToString();
    }
    public void selecIdioamFrase(int position)
    {
        Debug.Log("Estado del idioma: " + estadoIdioma);
        switch (estadoIdioma)
        {
            case 1: // Inglés
                if (wordlingles != null && wordlingles.Length > position)
                {
                    mensaje = wordlingles[position];
                    Debug.Log("Inglés: " + mensaje);
                }
                else
                {
                    Debug.LogWarning("Array de inglés vacío o índice fuera de rango.");
                }
                break;
            case 2: // Español
                if (wordlSspanhis != null && wordlSspanhis.Length > position)
                {
                    mensaje = wordlSspanhis[position];
                    Debug.Log("Español: " + mensaje);
                }
                else
                {
                    Debug.LogWarning("Array de español vacío o índice fuera de rango.");
                }
                break;
            case 3: // Portugués
                if (wordlSportugues != null && wordlSportugues.Length > position)
                {
                    mensaje = wordlSportugues[position];
                    Debug.Log("Portugués: " + mensaje);
                }
                else
                {
                    Debug.LogWarning("Array de portugués vacío o índice fuera de rango.");
                }
                break;
            default:
                mensaje = "Idioma no soportado";
                Debug.LogWarning("Idioma no soportado.");
                break;
        }
        texto.text = mensaje;



        /**
           if (estadoIdioma == 1) // ingles 
           {
               texto = wordlingles[position].ToString();
               Debug.Log("ingles ");
           }
           if (estadoIdioma == 2) //español  
           {
               texto = wordlSspanhis[position].ToString();
               Debug.Log("español ");
           }
           if (estadoIdioma == 3) //portugues 
           {
               texto = wordlSportugues[position].ToString(); 
               Debug.Log("portugues");
           }
        */

    }

   private void scripStart()
   {
        estadoIdioma = dataIDIOMA.estadoBoton;
        ramdomfrase();
        texto.text = mensaje.ToString();
       

    }
             
}
