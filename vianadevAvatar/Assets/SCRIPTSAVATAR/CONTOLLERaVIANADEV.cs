using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTOLLERaVIANADEV : MonoBehaviour
{
    public float verticalMove;
    public float horizontalMove;
    public float vel = 6f;
    public float velrotacion = 20f;
    private Animator ani;
    //public float x, y; 
    // Start is called before the first frame update
    //public bool ATACAR;
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");


        transform.Rotate(0, horizontalMove * Time.deltaTime * velrotacion, 0);
        transform.Translate(0, 0, verticalMove * Time.deltaTime * vel);

        ani.SetFloat("x", horizontalMove);
        ani.SetFloat("y", verticalMove);
        // combate 

    }
}
