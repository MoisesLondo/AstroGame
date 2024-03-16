using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private float tiempoEntreDisparos;
    [SerializeField] private KeyCode disparar;

    private float tiempoSiguienteDisparo;

private void Update()
{
    if (Input.GetKey(disparar) && Time.time >= tiempoSiguienteDisparo)
    {
        Disparar();
        tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
    }


}
    private void Disparar(){

        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
