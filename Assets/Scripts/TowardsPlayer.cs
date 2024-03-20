using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 5f;
    void Start()
    {
        player = FindObjectOfType<HeroKnight>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        // transform.rotation = Quaternion.LookRotation(player.transform.position);
        Destroy(gameObject, 8f);
    }
}
