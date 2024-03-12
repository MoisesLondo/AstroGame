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
    private int groundLayer; // Layer index for "Ground"

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.NameToLayer("Ground"); // Get ground layer index
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia, groundLayer); // Specify ground layer

        if (infoSuelo.collider != null) // Check if there's a collision
        {
            // Do nothing, enemy is on the ground (as defined by "Ground" layer)
        }
        else
        {
            Girar();
        }

        rb.velocity = new Vector2(velocidad, rb.velocity.y);
    }

    private void Girar()
    {
        derecha = !derecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Not used in this case, but can be used for other updates
    }
}