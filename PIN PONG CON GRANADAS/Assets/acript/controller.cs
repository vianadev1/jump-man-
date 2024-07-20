using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador
    public Animator ani;
    public float fuerzaImpulso = 10f; // Ajusta la fuerza del impulso según sea necesario

    void Update()
    {
        // Obtener entrada de teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * speed * Time.deltaTime;

        // Aplicar movimiento al jugador
        transform.Translate(movement);

        // Detecta si se ha hecho clic en el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Realiza acciones cuando se detecta un clic
            Debug.Log("Se ha detectado un clic!");
            ani.SetBool("shoot", true);

            // Puedes agregar aquí cualquier acción que desees realizar al detectar el clic
        }

    }


    public void endanimation()
    {
        ani.SetBool("shoot", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene la etiqueta "granada"
        if (collision.gameObject.CompareTag("granada"))
        {
            // Calcular la dirección hacia adelante del objeto
            Vector3 direccionAdelante = transform.forward;

            // Aplicar el impulso hacia adelante al objeto que colisionó
            collision.rigidbody.AddForce(direccionAdelante * fuerzaImpulso, ForceMode.Impulse);
        }
    }
}
