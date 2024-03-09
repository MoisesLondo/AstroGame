using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private float tiempoEntreDisparos;

    private float tiempoSiguienteDisparo;

private void Update()
{
    if (Input.GetButtonDown("Fire2") && Time.time >= tiempoSiguienteDisparo)
    {
        Disparar();
        tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
    }


}
    private void Disparar(){

        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
