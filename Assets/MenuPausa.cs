using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool juegoPausado = false;
    public GameObject menuPausaUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape))

     if (juegoPausado)
     {
        Reanudar();
     }
     else{
        Pausa();
     }

    }

    public void Reanudar(){

        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    void Pausa(){

        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void MenuPrincipal(){

        Debug.Log("Menu");
    }
    
    public void SalirJuego(){

        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
