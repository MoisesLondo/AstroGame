using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float velocidad;
    [SerializeField] Transform controladorSuelo;
    [SerializeField] float distancia;
    [SerializeField] bool derecha;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
        
        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if(infoSuelo == false){
            Girar();
        }
    }
    private void Girar(){

        derecha = !derecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
