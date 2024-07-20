using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManegerTrucho : MonoBehaviour
{
    [Header("sistema de restar  tiempo ")]
    [SerializeField] TextMeshProUGUI cronometroTxt;
    private float tiempo;
    public float tiempoInicial = 60f;
    public bool timerIsRunning = false;
    public GameObject animacionGranada;
    public ParticleSystem granadaS;
    public ParticleSystem splat;
    [Header("sistema de sumar   tiempo ")]
    // Referencia al material que se va a modificar
    public Material material;
    // Color original del material
    private Color originalColor;
    // Color temporal que se usará para el cambio
    private Color tempColor = Color.green;
    // Duración del cambio de color en segundos
    public float colorChangeDuration = 1.0f;
    [Header("sistema de reinicio de granada")]
    public GameObject granada;
    public Transform poscionInicialGranada;
    [Header("UI  ")]
    public GameObject gameover;
    public GameObject WIN;

    // Start is called before the first frame update
    void Start()
    {
        tiempoRest();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {

            if (tiempo > 0)
            {
                tiempo -= Time.deltaTime;
                UpdateTimerUI();

            }
            if (tiempo <= 0)
            {
                Debug.Log("¡Tiempo terminado!");

                
                gameover.SetActive(true);

                // animacion de explosion de la granada 

                animacionGranada.SetActive(true);
                granadaS.Play();
                splat.Play();
            }
        }

        



        
    }
    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(tiempo / 60);
        int seconds = Mathf.FloorToInt(tiempo % 60);

        cronometroTxt.text = minutes.ToString("00") + ":" + seconds.ToString("00");

    }
    void tiempoRest()
    {
        tiempo = tiempoInicial;
    }
    public void impactaGranada()
    {
        ChangeColorToGreenForDuration();
        tiempo += 5;
    

    }

    /// sistema de vida s
    public void ChangeColorToGreenForDuration()
    {
        // Verifica si el material es válido
        if (material == null)
        {
            Debug.LogWarning("Material not assigned.");
            return;
        }

        // Almacena el color original si aún no se ha hecho
        if (originalColor == default(Color))
        {
            originalColor = material.color;
        }

        // Cambia el color del material a verde
        material.color = tempColor;

        // Invoca un método para restaurar el color original después de cierto tiempo
        Invoke("RestoreOriginalColor", colorChangeDuration);
    }

    // Método para restaurar el color original del material
    private void RestoreOriginalColor()
    {
        // Verifica si el material es válido
        if (material == null)
        {
            Debug.LogWarning("Material not assigned.");
            return;
        }

        // Restaura el color original del material
        material.color = originalColor;
    }


    
    // Método para activar el siguiente objeto en la lista
    public void RESTART()
    {
        tiempo = tiempoInicial;
       
        WIN.SetActive(false);

    }
   

    public void CERRApp()
    {
        Application.Quit();

    }
}
