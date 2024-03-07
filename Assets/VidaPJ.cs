using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPJ : MonoBehaviour
{
    [SerializeField] private float vida;
    private ControlPJ controlPJ;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;

    private void Start(){

        controlPJ = GetComponent<ControlPJ>();
        animator = GetComponent<Animator>();
    }
    public void TomarDaño(float daño){
        
        vida -= daño;
        if(vida <= 0){
            Muerte();
        }
    }

    public void TomarDaño(float daño, Vector2 posicion){

        vida -= daño;
        animator.SetTrigger("Daño");
        StartCoroutine(perderControl());
        StartCoroutine(desactivarCollision());
        controlPJ.Rebote(posicion);
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
    }
}
