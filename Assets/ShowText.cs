using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    // Start is called before the first frame update

    // Movimiento del personaje
    public Text text;
    public Text text2;
    public Text text3;
    public Text text4;
    public Image image;
    public Image image2;

    // Salto
    public Text TextSalto;
    public Text TextSalto2;

    public Image imageSalto;
    public Image imageSalto2;

    void Start()
    {
        TextSalto.enabled = false;
        TextSalto2.enabled = false;
        imageSalto.enabled = false;
        imageSalto2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MostraMovimiento(5f));
        StartCoroutine(MostrarSalto(5f));
    }

    IEnumerator MostraMovimiento(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        text.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        text4.enabled = false;
        image.enabled = false;
        image2.enabled = false;

    }

    IEnumerator MostrarSalto(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        text3.enabled = true;
        text4.enabled = true;
        TextSalto.enabled = true;
        TextSalto2.enabled = true;
        imageSalto.enabled = true;
        imageSalto2.enabled = true;

    }
}
