using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    

    private bool disparando = false;

private void Update()
{
    if (Input.GetButtonDown("Fire2") && !disparando)
    {
        Disparar();
        disparando = true;
    }

    if (Input.GetButtonUp("Fire2"))
    {
        disparando = false;
    }
}
    private void Disparar(){

        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
