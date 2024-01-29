using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class barradepogreso : MonoBehaviour
{
    public Image barradesalto;
    public Transform perrito;
    public Transform progreoso_player;
    public float distancia_maxima = 691000f;
    public float posiconfinal;

    // Referencia al script de movimiento horizontal del perrito
    public float velocidadHorizontal = 2f;

    // Flag para indicar si el objeto vertical se está moviendo
    private bool verticalEnMovimiento = false;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
       
        barradesalto.fillAmount = progreoso_player.position.y / distancia_maxima;

        if (progreoso_player.position.y >= distancia_maxima)
        {
            verticalEnMovimiento = false;
        }

        if (verticalEnMovimiento)
        {
            // Agrega aquí tu lógica para el movimiento horizontal, por ejemplo:
            perrito.Translate(Vector3.right * velocidadHorizontal * Time.deltaTime);
        }

    }
}
