using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compañero : MonoBehaviour
{
    public GameObject player;
    public float velocidad;
    SpriteRenderer spriteRenderer;
    public float compañeroYPosition;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite();
        seguirPlayer();
    }

    void FlipSprite(){

        if(player.transform.position.x > transform.position.x){
            spriteRenderer.flipX = false;
    } else if(player.transform.position.x < transform.position.x)
    {
        spriteRenderer.flipX = true;
    }
}
    void seguirPlayer(){

        float distanciaPlayerX = player.transform.position.x - transform.position.x;
        float distanciaPlayerY = player.transform.position.y - transform.position.y;
        if(distanciaPlayerX < 2 && distanciaPlayerX > -2) return;
        if(distanciaPlayerY < 1 && distanciaPlayerY > 1)  return;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidad * Time.deltaTime);
    }
}