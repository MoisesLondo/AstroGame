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

    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote;

    [SerializeField] private float fuerzaSalto;

    [SerializeField] private LayerMask queEsSuelo;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private Vector3 dimCaja;

    [SerializeField] private bool enSuelo;

    private Animator animator;

    private bool salto = false;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMov;

        if(Input.GetButtonDown("Jump")){
            
            salto = true;
        }

        if (movHorizontal != 0f){

            animator.SetBool("isRunning", true);
        }

        else{
            animator.SetBool("isRunning", false);
        }

    }

    private void FixedUpdate()
    {
        

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimCaja, 0f, queEsSuelo);

        animator.SetBool("enSuelo",enSuelo);

        if(sePuedeMover){
            Mover(movHorizontal * Time.fixedDeltaTime, salto);
        }



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
    private void Girar()
    {
        derecha = !derecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos(){

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position,dimCaja);
    }
}
