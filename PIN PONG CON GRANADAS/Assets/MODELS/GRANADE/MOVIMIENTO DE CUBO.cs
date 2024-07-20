using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVIMIENTODECUBO : MonoBehaviour
{
    // Velocidad de movimiento del cubo
    public float moveSpeed = 5f;

    // Direcci�n del movimiento
    private int direction = 1;

    // Posici�n inicial del cubo
    private Vector3 initialPosition;

    void Start()
    {
        // Almacena la posici�n inicial del cubo
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento en la direcci�n actual y con la velocidad especificada
        float movement = moveSpeed * direction * Time.deltaTime;

        // Mueve el cubo en la direcci�n actual
        transform.Translate(Vector3.right * movement);

        // Si el cubo alcanza cierto l�mite, cambia la direcci�n
        if (transform.position.x >= initialPosition.x + 5f || transform.position.x <= initialPosition.x - 5f)
        {
            direction *= -1;
        }
    }
}
