using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullarAereo : MonoBehaviour
{

    [SerializeField] private float velocidadTiempo;
    [SerializeField] private Transform[] puntosMov;
    [SerializeField] private float distanciaMin;
    private int siguientePaso = 0;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMov[siguientePaso].position, velocidadTiempo * Time.deltaTime);

        if(Vector2.Distance(transform.position, puntosMov[siguientePaso].position) < distanciaMin)
        {
            siguientePaso += 1;
            if(siguientePaso >= puntosMov.Length){
                siguientePaso = 0;
            }
            Girar();
        }

    }

    private void Girar(){

        if(transform.position.x < puntosMov[siguientePaso].position.x){

            spriteRenderer.flipX = true;
        }
        else{

            spriteRenderer.flipX = false;

        }
    }
}
