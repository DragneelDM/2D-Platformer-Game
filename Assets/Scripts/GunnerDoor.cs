using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerDoor : MonoBehaviour
{
    [SerializeField] GameObject Gunner;
    [SerializeField] Transform Spawnpoint;

    void Intro(){
        Instantiate(Gunner, Spawnpoint.position, Spawnpoint.rotation);
    }
}
