using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Animator door;
    [SerializeField] Sprite switchON;
    bool waiting = true;

    private void OnTriggerEnter2D(Collider2D other) {
        if(waiting){
        GetComponent<SpriteRenderer>().sprite = switchON;
        SoundManager.Instance.Play(Sounds.SwitchActivated);
        door.SetBool("IntroStart", true);
        waiting = false;
        }
    }
}
