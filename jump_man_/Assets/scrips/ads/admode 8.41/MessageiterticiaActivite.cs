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
    [Header ("cuenta regresiva")]
    public TextMeshProUGUI textoContador;
    private int contador;
    private float tiempo_contador;
    [Header("anucios ")]
    public adsMasterAbmode ads;
    public int _cantidad_caidas_ads;
    public GameObject banner_de_contar;
    
    private void Start()
    {
        ramdomfrase();
        texto.text = mensaje;
        IniciarContador();
        ads.LoadInterstitalAd();
        
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        tiempo_contador -= Time.deltaTime;
        contador = Mathf.RoundToInt(tiempo_contador);


        if (_cantidad_caidas_ads >=1)
        {
            banner_de_contar.SetActive(true);
            if (tiempo >= 6 && _cantidad_caidas_ads >= 1)
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

        if (tiempo >= 6 )
        {
            _cantidad_caidas_ads += 1;
          
            tiempo = 0;
            tiempo_contador = 6;
            ads.LoadInterstitalAd();

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
                mensaje = "champions don't give up";
                break;
            case 2:
                mensaje = "go away you are a loser";
                break;
            case 3:
                mensaje = "jajajaajaj loser ";
                break;
            case 4:
                mensaje = "you could do it better";

                break;
            case 5:
                mensaje = "let's go to the top";
                break;
        }
    }
    private void IniciarContador()
    {
        contador = 6;
    }
    private void DecrementarContador()
    {
        contador--;
    }
    private void ActualizarTextoContador()
    {
        textoContador.text = contador.ToString();
    }
}
