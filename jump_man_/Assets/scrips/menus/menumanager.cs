using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // ESTOY HAY QUE USARLO PARA PODER TRANSMITIRLO AL MENU CAMVAS 

public class menumanager : MonoBehaviour
{
    public GameObject pagos;
    public GameObject Menu;
    public GameObject pausa;
    public GameObject winner;
    public Transform starPosition;
    /// player 
    public GameObject player; 
    void Start()
    {
                

    }
    void Update()
    {
      pagos = GameObject.Find("pagos "); // copiar muy bien la referencia al objecto 
        if (Menu.activeSelf == true || pausa.activeSelf == true)
        {
            player.SetActive(false);

        }
        else
        {
            player.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D ganas)
    {
        if (ganas.CompareTag("nivel32")) //usamos los tag para comparar objectos 
        {

            winner.SetActive(true);

            player.SetActive(false);
            player.transform.position = starPosition.position;
            Debug.Log("ganas");


        }


    }


}
