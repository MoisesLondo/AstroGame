using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;

    private Animator animator;
    
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetButtonDown("Fire1")){

            Golpe();
        }
        
    }
    private void Golpe(){

        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach(Collider2D colisionador in objetos){

            if(colisionador.CompareTag("Enemigo")){

                colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }

        }
    }
}
