using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            other.gameObject.GetComponent<PlayerController>().Death();
         }
    }
}
