using Unity.VisualScripting;
using UnityEngine;

public class PenguinSwimLu : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float verticalGravity = 0.5f; 

    public bool IsFacingRight => !spriteRenderer.flipX;


    private Rigidbody2D rb;
    private Animator animatorController;

    private Vector2 movTeclas;
    private SpriteRenderer spriteRenderer;

    private GameObject respawn;

    GameObject audioManajerObj;

    void Start()
    {

        Debug.Log(this.gameObject.name);
        rb = this.GetComponent<Rigidbody2D>();
        animatorController = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

       
        rb.gravityScale = 5f;

        //Opcional dependiendo de donde respawnee el pingu si muere -en el lobby o en el mj-
        respawn = GameObject.Find("Respawn");
        transform.position = respawn.transform.position;
    }

    void Update()
    {
        //  WASD 
        movTeclas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Flip izda/dcha
        if (movTeclas.x > 0)
            spriteRenderer.flipX = false;
        else if (movTeclas.x < 0)
            spriteRenderer.flipX = true;


        Vector2 velocity = movTeclas.normalized * swimSpeed;

        // Si no nada la gravedad hace que caiga
        if (movTeclas == Vector2.zero)
            velocity.y = -verticalGravity;

        rb.velocity = velocity;

    }

    void TakeDamage()
{
    GameManager.vidas = GameManager.vidas -1;

    Debug.Log("vidas: " + GameManager.vidas);
    Respawn();
        
}

    void Respawn()
    {
        /*GameManagerBuceo.vidas = GameManagerBuceo.vidas -1;
        Debug.Log("vidas: " + GameManagerBuceo.vidas);*/

         transform.position = respawn.transform.position;
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo")) //Si te chocas contra un enemigo haces respawn
        {
             TakeDamage();
        }

    }
    }


