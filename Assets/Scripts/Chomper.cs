using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    [SerializeField] Vector3 startPatrol;
    [SerializeField] Vector3 endPatrol;

    [SerializeField] AnimationCurve speed;
    float current = 0f; // Start at 0 to move from startPatrol to endPatrol
    bool movingForward = true; // Flag to track the movement direction

    private void Update()
    {
        // If chomper reaches either startPatrol or endPatrol, change direction
        if (current >= 1f || current <= 0f)
        {
            movingForward = !movingForward;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }


        float target = movingForward ? 1f : 0f;

        current = Mathf.MoveTowards(current, target, 0.5f * Time.deltaTime);
        transform.position = Vector3.Lerp(startPatrol, endPatrol, speed.Evaluate(current));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerController>()?.Death();
    }
}
