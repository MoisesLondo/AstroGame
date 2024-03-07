using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField] private float vida;

    private Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

     public void TomarDaño(float daño)
    {
        vida -= daño;

        if(vida <= 0){
            Muerte();
        }
    }

    private void Muerte(){
        Destroy(gameObject);
        animator.SetTrigger("Muerte");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
