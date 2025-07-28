using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class Movimiento_Fotos : MonoBehaviour
{
    public Rigidbody2D PlayerRb;
    private Vector2 moveInput;



    public bool mirarDerecha = true;

    private Animator animatorController;

    float movTeclasX;

    float movTeclasY;

    private GameObject FotoObj; // Referencia al objeto que se puede interactuar

    //VELOCIDAD MOVIMIENTO DEL PERSONAJE
    public float normalSpeed = 3f;
    public float slowedSpeed = 2f;
    private float currentSpeed;
    private Vector2 movimiento;

    //INTERACTUAR
    private GameObject objetoCercano;



    private void Start()
    {

        animatorController = GetComponent<Animator>();


        //RECOGE LA VELOCIDAD
       PlayerRb = GetComponent<Rigidbody2D>();
       currentSpeed = normalSpeed;

    }

    private void Update()
    {


        //Mov personaje
        movTeclasX = Input.GetAxisRaw("Horizontal");
        movTeclasY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(movTeclasX, movTeclasY).normalized;
 
        Debug.Log(moveInput);



        //CAMINAR ANIMACION DCHA-IZQ
        if (movTeclasX != 0)
        {
            animatorController.SetBool("activaCaminar", true);

        }
        else
        {
            animatorController.SetBool("activaCaminar", false);
            animatorController.SetBool("IdleSide", true);
        }
        ;

        //CAMINAR ANIMACION ARRIBA
        if (movTeclasY != 0)
        {
            animatorController.SetBool("caminarUp", true);

        }
        else
        {
            animatorController.SetBool("caminarUp", false);
            animatorController.SetBool("IdleBack", true);
        }

        //CAMINAR ABAJO
        if (movTeclasY != 0)
        {
            animatorController.SetBool("caminarDown", true);

        }
        else
        {
            animatorController.SetBool("caminarDown", false);
            animatorController.SetBool("Static", true);
        } 
    
    


        //Mov derecha
        if (movTeclasX > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            mirarDerecha = true;

            //Mov izquierda   
        }
        else if (movTeclasX < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            mirarDerecha = false;

        } 
        
}
    private void FixedUpdate()
    {
        PlayerRb.MovePosition(PlayerRb.position + moveInput * currentSpeed * Time.fixedDeltaTime);
    }



    ///ZONA RALENTIZADA////////////
/*    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SlowZone"))
        {
            currentSpeed = slowedSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SlowZone"))
        {
            currentSpeed = normalSpeed;
        }
    } 
    
  ///ZONA RALENTIZADA////////////*/
}


                                                               