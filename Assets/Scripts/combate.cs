using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combate : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetButtonDown("Fire1")){

            Golpe();
        }
        
    }
    private void Golpe(){

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach(Collider2D colisionador in objetos){

            if(colisionador.CompareTag("Enemigo")){

                colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }

        }
    }
}
