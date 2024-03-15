using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moverFondo : MonoBehaviour
{
    public RawImage _img;
    public float y;
    public float x;

    void Update(){

        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(x,y) * Time.deltaTime, _img.uvRect.size);
    }
}
