using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private float tiempoEntreDisparos;
    [SerializeField] private KeyCode disparar;

    private Animator animator;
    private float tiempoSiguienteDisparo;
    private enum State {NoShoot, Shoot}
    State state = State.NoShoot;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        StateDisparo(state);
         if (state == State.Shoot && Time.time >= tiempoSiguienteDisparo)
        {
            Disparar();
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    private void StateDisparo(State state)
    {
        if (Input.GetKey(disparar)){
            state = State.Shoot;
        }
        animator.SetInteger("Disparo", (int)state);
    }
    private void Disparar(){

        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
