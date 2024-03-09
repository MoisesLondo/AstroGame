using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDaño : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other){

    if(other.gameObject.CompareTag("Player")){

        other.gameObject.GetComponent<VidaPJ>().TomarDaño(20, other.GetContact(0).normal);
   }
}
}
