using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVIMIENTODECUBO : MonoBehaviour
{
    // Velocidad de movimiento del cubo
    public float moveSpeed = 5f;

    // Dirección del movimiento
    private int direction = 1;

    // Posición inicial del cubo
    private Vector3 initialPosition;

    void Start()
    {
        // Almacena la posición inicial del cubo
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento en la dirección actual y con la velocidad especificada
        float movement = moveSpeed * direction * Time.deltaTime;

        // Mueve el cubo en la dirección actual
        transform.Translate(Vector3.right * movement);

        // Si el cubo alcanza cierto límite, cambia la dirección
        if (transform.position.x >= initialPosition.x + 5f || transform.position.x <= initialPosition.x - 5f)
        {
            direction *= -1;
        }
    }
}
