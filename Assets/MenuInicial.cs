using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public static bool juegoPausado = false;
    public void Jugar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Reanudar();
        Physics2D.IgnoreLayerCollision(6,7,false);
    }

    public void Salir(){
        Debug.Log("Salió");
        Application.Quit();
    }
    public void Reanudar(){

        Time.timeScale = 1f;
        juegoPausado = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
