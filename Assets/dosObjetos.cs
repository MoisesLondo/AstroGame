using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dosObjetos : MonoBehaviour
{
    public Transform obj1, obj2;
    private Vector2 vel,pos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        pos = (obj1.position + obj2.position) * 0.5f;
        transform.position = Vector2.SmoothDamp(transform.position, pos, ref vel, speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        
    }
}
