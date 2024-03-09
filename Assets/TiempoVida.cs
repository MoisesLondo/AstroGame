using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoVida : MonoBehaviour
{
    [SerializeField] private float tiempoVida;
    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

}
