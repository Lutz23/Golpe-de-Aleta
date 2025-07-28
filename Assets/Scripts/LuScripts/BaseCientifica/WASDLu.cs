using UnityEngine;

public class WASDLu : MonoBehaviour
{
    public float walkSpeed = 5f;
   

    public bool IsFacingRight => !spriteRenderer.flipX;


    private Rigidbody2D rb;
    private Animator animatorController;
    private SpriteRenderer spriteRenderer;

    private Vector2 inputRaw;
    private Vector2 lastMoveDirection = Vector2.down;


    //private GameObject respawn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        Time.timeScale = 1f;

       
    }

    void Update()
    {
        //  WASD 
        inputRaw = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Vector2 velocity = movTeclas.normalized * walkSpeed;
        
        Vector2 inputNormalized = inputRaw.normalized;

        rb.velocity = inputNormalized * walkSpeed;


        if (inputNormalized.x > 0)
            spriteRenderer.flipX = false;
        else if (inputNormalized.x < 0)
            spriteRenderer.flipX = true;


        /*Flip izda/dcha
        if (movTeclas.x > 0)
            spriteRenderer.flipX = false;
        else if (movTeclas.x < 0)
            spriteRenderer.flipX = true;*/



    
        animatorController.SetFloat("Horizontal", inputNormalized.x);
        animatorController.SetFloat("Vertical", inputNormalized.y);
        animatorController.SetBool("IsMoving", inputRaw.magnitude > 0.01f);

        /*if (movTeclas.sqrMagnitude > 0.01f)
        {
            animatorController.SetFloat("LastMoveX", movTeclas.x);
            animatorController.SetFloat("LastMoveY", movTeclas.y);

        }*/
        
        Debug.Log($"Normalized Input - X: {inputNormalized.x}, Y: {inputNormalized.y}");


    }

    }


