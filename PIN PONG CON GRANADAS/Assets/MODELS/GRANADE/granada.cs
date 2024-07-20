using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granada : MonoBehaviour
{
    public float fuerzaImpulso = 20f; // Ajusta la fuerza del impulso según sea necesario
    public GameManegerTrucho manager;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene la etiqueta "raqueta"
        if (collision.gameObject.CompareTag("raqueta"))
        {
            // Calcular la dirección hacia adelante de la granada
            Vector3 direccionAdelante = transform.forward;

            // Aplicar el impulso hacia adelante a la granada
            GetComponent<Rigidbody>().AddForce(direccionAdelante * fuerzaImpulso, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("pared"))
        {
            manager.impactaGranada();
        }
    }
}


