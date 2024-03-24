using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    [SerializeField] private Vector3 _startPatrol;
    [SerializeField] private Vector3 _endPatrol;
    [SerializeField] private GameObject _burstVfX;

    [SerializeField] private AnimationCurve _speed;
    private float _jumpForce = 200f;
    private float _current = 0f; // Current progress along the path
    private bool _movingForward = true; // Flag to track the movement direction

    private void Update()
    {
        // If chomper reaches either startPatrol or endPatrol, change direction
        if (_current >= 1f || _current <= 0f)
        {
            _movingForward = !_movingForward; // Toggle movement direction
            // Flip the sprite
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        // Determine the target position based on movement direction
        float target = _movingForward ? 1f : 0f;

        // Move chomper smoothly towards the target position
        _current = Mathf.MoveTowards(_current, target, 0.5f * Time.deltaTime);
        // Update chomper's position along the patrol path
        transform.position = Vector3.Lerp(_startPatrol, _endPatrol, _speed.Evaluate(_current));
    }


    // For the Main Collider
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerController>()?.Death();
    }

    // For the Second Collider on top
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidBody))
        {
            rigidBody.AddForce(new Vector2(0, _jumpForce));
        }

        Instantiate(_burstVfX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
