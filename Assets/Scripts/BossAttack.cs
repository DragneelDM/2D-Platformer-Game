using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    Transform player;

    private void Start() {
        player = FindObjectOfType<PlayerController>(). transform;
    }

    public void Shoot(){
        Instantiate(projectile, new Vector2(player.position.x, transform.position.y), transform.rotation);
    }
}
