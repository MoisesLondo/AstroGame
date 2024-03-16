using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMov : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMov;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D rb2d;

    private void Awake(){

        material = GetComponent<SpriteRenderer>().material;
        rb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update(){

        offset = (rb2d.position.x / 10) * velocidadMov * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
