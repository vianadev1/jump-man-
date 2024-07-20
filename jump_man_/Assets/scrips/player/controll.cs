using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // ESTOY HAY QUE USARLO PARA PODER TRANSMITIRLO AL MENU CAMVAS 

public class controll : MonoBehaviour
{
    public float Moverse_velocidad = 5f; // una variable cualquiera en este caso para el movimiento del tranform 
    public float ForceJump = 8.2f; // una variable cualquiera en este caso para el movimiento del tranform 
    float ForceJumpHorizontal = 1.8f;
    private bool Right;
    private bool Left;
    private bool jump;
    public float tiempo;
    float tiempoDesalto;
    bool orientacion;
    Rigidbody2D rigibody1;
    public LayerMask groundMask;    // mascara del suelo  esto layermask instacia las capas en la variable se usa para saltar 
    /// /////////  control por teclado 
    int limitesSaltos = 1;
    public int saltoshechos;
    [SerializeField] Image colordelboton;
    private Animator _animator;
    public GameObject jumpsounds, golpesounds;
    public float raycast_linmits = 1.75f;
    //barrra de salto 
    public Image barradesalto;
    public float salto_maximo = 2.8f; // tiempo
    string estasaltando;
    // autoguardado 
    public GameObject Menu;
    [Header("limites ")]
    public float limites,limites2;


    void Awake()
    {
        rigibody1 = GetComponent<Rigidbody2D>();
        saltoshechos = 0;
        tiempo = 0;
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
       
        #region MOVERSE

     // orientacion 
            if (orientacion == true)
            {
                _animator.SetBool("rigth", true); //animacion de sntido  derecha 
                _animator.SetBool("left", false); //animacion de sntido   
            }
            if  (orientacion == false)
            {
                _animator.SetBool("rigth", false); /// izquierda 
                _animator.SetBool("left", true);
            }

        /// entradas de botones pc //////////////
        if (Right == true || Input.GetKey(KeyCode.RightArrow)) // esto solo puede ser caminar 
        {
            orientacion = true; //para saber en que posicion esta el jugador 
            if (jump == false && saltoshechos < limitesSaltos)
            {
               /// _animator.SetBool("walkLeft", false);// caminar 
                _animator.SetBool("walkRigth", true);
                transform.Translate(Vector2.right * Moverse_velocidad * Time.deltaTime);
            }
        }
        else
        {
            _animator.SetBool("walkRigth", false);
        }

        if (Left == true || Input.GetKey(KeyCode.LeftArrow))
        {
            if (jump == false && saltoshechos < limitesSaltos)
            {
                orientacion = false;
               /// _animator.SetBool("walkRigth", true);
                _animator.SetBool("walkLeft", true);
                transform.Translate(Vector2.left * Moverse_velocidad * Time.deltaTime);
            }
        }
        else
        {
            _animator.SetBool("walkLeft", false);
        }
        float restrincionx = Mathf.Clamp(transform.position.x, limites*-1, limites2); // restriciones float restrincionx = Mathf.Clamp(transform.position.x, -17.5f, 17.5f);   
        float restrinciony = Mathf.Clamp(transform.position.y, -12.5f, 1200.5f);

        transform.position = new Vector3(restrincionx, restrinciony, 0);
        #endregion
        #region SALTAR 
        if (jump == true)  //comprueba cuanto tiempo tocaron el botton 
        {
            colordelboton.color = new Color(1, 0.7f, 0.08f);
            // QUE PASE UN TIEMPO Y SALTA //
            tiempo += Time.deltaTime ;
            //Debug.Log(tiempo);
             barradesalto.fillAmount = tiempo / salto_maximo ;
                    if (orientacion == true)
                    { 
                        _animator.SetBool("prejumpRigth", true); //derecha 
                    }
                    if  (orientacion == false)
                    {
                        _animator.SetBool("prejump", true); // izquierda sienta 
                    }
                if (tiempo >= 2.8f )
               {
              //  barradesalto.fillAmount = salto_maximo / tiempo;

                ForceJump = tiempo * 7.2F;
                ForceJumpHorizontal = tiempo * 2.5f;


                if (orientacion == true)
                {
                    _animator.SetBool("jumpRigth", true);
                }
                if (orientacion == false)
                {
                    _animator.SetBool("jump", true);
                }
                saltar();
                tiempo = 1;
            }
        }
        if (jump == false)
        {
            colordelboton.color = new Color(0.0754717f, 0.0751157f, 0.0751157f);
           if (tiempo > 0 && tiempo < 2.79f)
            {
                ForceJump = tiempo * 7.2F;
                ForceJumpHorizontal = tiempo * 3.2f;
                if (orientacion == true)
                {
                    _animator.SetBool("jumpRigth", true);
                }
                if (orientacion == false)
                {
                    _animator.SetBool("jump", true);
                }
                saltar();
                tiempo = 0;
            }

        }    
        Debug.DrawRay(this.transform.position, Vector2.down * 1.8F, Color.red);  // ryacast del debug  
        #endregion

        

    }
    #region SALTAR FUNCIONES


    void saltar()
    {

        if (_animator.GetBool("rigth") == true)
        {
            if (saltoshechos < limitesSaltos)
            {
                if (IsTouchingTheGround()) // SE LLAMA EL METODO 
                {
                    jumpsounds.SetActive(true); //sonidos 
                    rigibody1.AddForce(Vector2.up * ForceJump, ForceMode2D.Impulse);
                    rigibody1.AddForce(Vector2.right * ForceJumpHorizontal, ForceMode2D.Impulse);
                    //_animator.SetBool("jumpRigth", false);
                }
                //_animator.SetBool("jumpRigth", false);
                saltoshechos++; //aumenta
            }
           // _animator.SetBool("jumpRigth", false);
           /// _animator.SetBool("prejumpRigth", false); //derecha 
        }
        if (_animator.GetBool("left") == true)
        {
            if (saltoshechos < limitesSaltos)
            {
                if (IsTouchingTheGround()) // SE LLAMA EL METODO 
                {
                    rigibody1.AddForce(Vector2.up * ForceJump, ForceMode2D.Impulse);
                    rigibody1.AddForce(Vector2.left * ForceJumpHorizontal, ForceMode2D.Impulse);
                    //_animator.SetBool("jump", false);
                }
               
                saltoshechos++; //aumenta
            }
            //_animator.SetBool("jump", false);
            ///_animator.SetBool("prejump", false);
        }
    }
      
    //  rycast para ek salto 
    bool IsTouchingTheGround() /// detecta si est aen el piso 
    {
        int numberOfRays = 100; // Número de rayos que quieres para hacer el rayo más ancho
        float raycastWidth = 2.5f; // Ancho del rayo

        // Calcula el espacio entre cada rayo
        float raySpacing = raycastWidth / (numberOfRays - 1);

        // Itera sobre cada rayo
        for (int i = 0; i < numberOfRays; i++)
        {
            // Calcula la posición del rayo actual
            Vector2 rayOrigin = new Vector2(this.transform.position.x - raycastWidth / 2 + i * raySpacing, this.transform.position.y);

            // Realiza el raycast
            if (Physics2D.Raycast(rayOrigin, Vector2.down, raycast_linmits, groundMask))
            {
                // Tu lógica aquí si al menos uno de los rayos toca el suelo
                //Debug.Log("*** lo toca ****");
                return true;
            }
        }

        // Si ninguno de los rayos toca el suelo
        //Debug.Log("no lo esta tocando ");
        return false;
    }
    //FUNCION PRA DETECTAR EL SUELO EN EL SALTO CON SU COLISSION  /////////////jump 
    void OnCollisionEnter2D(Collision2D OBJ)
    {
        if (OBJ.collider.tag == "piso")
        {
            saltoshechos = 0;
            _animator.SetBool("jumpRigth", false);
            _animator.SetBool("jump", false);
            _animator.SetBool("prejump", false);
            _animator.SetBool("prejumpRigth", false);
            jumpsounds.SetActive(false);

        }
    }
    
    #endregion
    #region INPUTS BUTTON
    public void ButtonRight()
    {

        Right = true;
    }
    public void ButtonNORight()
    {

        Right = false;
    }
    public void ButtonLeft()
    {

        Left = true;
    }
    public void ButtonNOLeft()
    {

        Left = false;
    }
    
    public void Buttonjump()
    {
        jump = true;

    }
    public void ButtonNOjump()
    {

        jump = false;
    }
    #endregion

    //autoguardado 

}