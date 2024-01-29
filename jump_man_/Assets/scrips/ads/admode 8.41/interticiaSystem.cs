using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class interticiaSystem : MonoBehaviour
{
    public Transform player;
    public float fallThreshold = 10f; // Altura a la que se considera una caída
    public GameObject FallScreen; // Objeto de pantalla de juego terminado (debe tener un componente CanvasGroup para controlar la opacidad)

    public float initialPlayerY; // Almacena la posición inicial del jugador en el eje Y
    private float tiempo;
  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 2)
        {
            UpdateInitialPlayerY();
            tiempo = 0;
        }
        // Verifica si el jugador ha caído por debajo de la altura específica
        if (player.position.y < initialPlayerY - fallThreshold)
        {
            Debug.Log("CAISTE");
            // Muestra la pantalla de juego terminado
            ShowGameOverScreen();
            //caundo valla a mostarta el ads muestre un indicador  y la frase motivaccional 
        }
    }
    private void UpdateInitialPlayerY()
    {
        // Guarda la posición actual del jugador como la nueva posición inicial
        Debug.Log("POSICONGUARDADA");
        initialPlayerY = player.position.y;
    }
    private void ShowGameOverScreen()
    {
        //muestra pantalla de que caiste mas de la posicon inicial 
        FallScreen.SetActive(true);



    }

   



        




    
}

