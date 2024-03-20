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

    // Salto
    public Text TextSalto2;
    public Image imageSalto2;

    void Start()
    {
        imageSalto2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MostraMovimiento(8f));
    }

    IEnumerator MostraMovimiento(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        text.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        text4.enabled = false;
        image.enabled = false;
        TextSalto2.enabled = false;

    }
}