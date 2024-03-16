using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VidaPJ : MonoBehaviour
{
    [SerializeField] private float vida;
    private ControlPJ controlPJ;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;
    public event EventHandler MuerteJugador;
    float xInicial,yInicial;
    private Rigidbody2D rb2D;

    private void Start(){

        xInicial = transform.position.x;
        yInicial = transform.position.y;

        controlPJ = GetComponent<ControlPJ>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    public void TomarDaño(float daño){
        
        vida -= daño;
        if(vida <= 0){
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Muerte();
            
        }
    }

    public void TomarDaño(float daño, Vector2 posicion){

        vida -= daño;
        if(vida > 0){
        animator.SetTrigger("Daño");
        StartCoroutine(perderControl());
        StartCoroutine(desactivarCollision());
        controlPJ.Rebote(posicion);}
        else{
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Muerte();
        }
    }
    public void Destroy(){
        Destroy(gameObject);

    }
    private IEnumerator desactivarCollision(){
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(6,7,false);
    }
    private IEnumerator perderControl(){
        controlPJ.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        controlPJ.sePuedeMover = true;
    }

    private void Muerte(){
        animator.SetTrigger("Muerte");
        Recolocar();
    }

    public void Recolocar(){

        transform.position = new Vector3(xInicial,yInicial,0);
    }

}
