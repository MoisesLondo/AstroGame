using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuMuerte : MonoBehaviour
{  
    [SerializeField] private GameObject menuGameOver;
    private VidaPJ jugador;
    public static bool juegoPausado = false;

    public void Start(){

        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaPJ>();
        jugador.MuerteJugador += ActivarMenu;
    }

    public void ActivarMenu(object sender, EventArgs e){

        menuGameOver.SetActive(true);
        Pausa();
    }
    public void Reiniciar(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Reanudar();
        Physics2D.IgnoreLayerCollision(6,7,false);
    }
    public void MenuInicial(string nombre){

        SceneManager.LoadScene(nombre);
    }
    public void Salir(){

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    void Pausa(){

        Time.timeScale = 0f;
        juegoPausado = true;
    }
    public void Reanudar(){

        Time.timeScale = 1f;
        juegoPausado = false;
    }
}
