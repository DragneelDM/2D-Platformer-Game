using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePreferred : MonoBehaviour
{
    [SerializeField] GameObject[] garbages;
    GameObject UIManager;
    private void OnTriggerEnter2D(Collider2D other) {
        foreach(GameObject garbage in garbages){
            Destroy(garbage);
        }
    }

    public void DeleteUIManager(){
        Destroy(FindObjectOfType<UIManager>().gameObject);
    }
}
