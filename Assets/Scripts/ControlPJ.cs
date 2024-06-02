using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPJ : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float movHorizontal = 0f;
    [SerializeField] private float velocidadMov;
    [SerializeField] private float suavizadoMov;
    private Vector3 velocidad = Vector3.zero;
    private bool derecha = true;
    private Vector2 input;

    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote;

    [SerializeField] private float fuerzaSalto;

    [SerializeField] private LayerMask queEsSuelo;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private Vector3 dimCaja;

    [SerializeField] private bool enSuelo;

    [SerializeField] private KeyCode der;
    [SerializeField] private KeyCode izq;
    [SerializeField] private KeyCode arriba;
    [SerializeField] private float velocidadEscalar;
    private BoxCollider2D boxCollider2D;
    private float gravedad;
    private bool escalando;


    private Animator animator;
    
    // Intento de Algo
    private enum MovementState {idle, running , jumping, falling}
    private MovementState state = MovementState.idle;
    private bool salto = false;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        gravedad = rb2D.gravityScale;
    }

    private void Update()
    {
        input.y = Input.GetAxisRaw("Vertical");
        float horizontal = 0f; 
        
        if (Input.GetKey(der))
        {
            horizontal = 1f;
        }
        else if (Input.GetKey(izq))
        {
            horizontal = -1f;
        }
        movHorizontal = horizontal * velocidadMov;

        if(Input.GetKey(arriba)){
            salto = true;
        }

        if (movHorizontal != 0f){

            animator.SetBool("isRunning", true);
        }

        else{
            animator.SetBool("isRunning", false);
        }
        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimCaja, 0f, queEsSuelo);

        animator.SetBool("enSuelo",enSuelo);

        if(sePuedeMover){
            Mover(movHorizontal * Time.fixedDeltaTime, salto);
        }


        Escalar();
        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoMov);

        if (mover > 0 && !derecha)
        {
            Girar();
        }
        else if (mover < 0 && derecha)
        {
            Girar();
        }

        if(enSuelo && saltar){

            enSuelo = false;
            rb2D.AddForce(new Vector2(0f,fuerzaSalto));


        }
    }
    public void Rebote(Vector2 puntoGolpe){

        rb2D.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);


    }

    private void Escalar(){

        if((input.y != 0 || escalando) && (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Escaleras")))){
            Vector2 velocidadSubida = new Vector2(rb2D.velocity.x, input.y * velocidadEscalar);
            rb2D.velocity = velocidadSubida;
            rb2D.gravityScale = 0;
            escalando = true;
        }else{
            rb2D.gravityScale = gravedad;
            escalando = false;
        }
        if(enSuelo){
            escalando = false;
        }
    }
    private void Girar()
    {
        derecha = !derecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos(){

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position,dimCaja);
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (movHorizontal > 0f || movHorizontal < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb2D.velocity.y > 1f)
        {
            state = MovementState.jumping;
        }
        else if(rb2D.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        animator.SetInteger("State", (int)state);
    }
}
