using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] bool autoShoot = false;
    [SerializeField] float durationTime = 3f;
    [SerializeField] float elaspedTime = 0f;
    Transform player;

    private void Start() {
        player = FindObjectOfType<PlayerController>(). transform;
    }


    private void Update(){
        if(autoShoot){
            elaspedTime += Time.deltaTime;

            if(elaspedTime > durationTime){
                Instantiate(projectile, new Vector2(player.position.x, transform.position.y), transform.rotation);
                elaspedTime = 0f;
            }
        }
    }

    public void Shoot(){
        Instantiate(projectile, new Vector2(player.position.x, transform.position.y), transform.rotation);
    }
}
