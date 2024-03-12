using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour, iDaño
{
    private Animator animator;

    public Rigidbody2D rb2d;

    public Transform jugador;

    private bool derecha = true;

    [SerializeField] private float vida;

    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;

    // [SerializeField] private BarraDeVida barraDeVida;

    private void Start(){

        animator = GetComponent<Animator>();
        rb2d =  GetComponent<Rigidbody2D>();
        // barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update(){

        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }

    public void TomarDaño(float daño){
        
        vida -= daño;
        if(vida <= 0){
            Muerte();
            Physics2D.IgnoreLayerCollision(6,7,true);
        }
    }

    private void Muerte(){
        animator.SetTrigger("Muerte");
        Destroy(gameObject);
    }

    public void MirarJugador(){

        if((jugador.position.x > transform.position.x && !derecha) || (jugador.position.x < transform.position.x && derecha)){

            derecha = !derecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque(){

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach(Collider2D colision in objetos){

            if(colision.CompareTag("Player")){

                colision.GetComponent<VidaPJ>().TomarDaño(dañoAtaque);
            }
        }
    }
    private void OnDrawGizmos(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}

