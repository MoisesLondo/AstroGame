using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadJefe : MonoBehaviour
{
    [SerializeField] private float daño;
    [SerializeField] private Vector2 dimCaja;
    [SerializeField] private Transform posCaja;
    [SerializeField] private float tiempoVida;
    public void Start()
    {
        Destroy(gameObject,tiempoVida);
    }

    // Update is called once per frame
   public void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posCaja.position, dimCaja, 0f);

        foreach(Collider2D colision in objetos){

            if(colision.CompareTag("Player")){

                colision.GetComponent<VidaPJ>().TomarDaño(daño);
            }
        }
    }
    
}
