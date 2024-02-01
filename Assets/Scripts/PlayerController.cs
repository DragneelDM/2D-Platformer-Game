using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    Animator animator;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update() {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));

        // Turn Backwards
        Vector3 Backface = transform.localScale;
        Backface.x = speed < 0 ? (-1 * Mathf.Abs(Backface.x)) : Mathf.Abs(Backface.x);
        transform.localScale = Backface;
    }
}
