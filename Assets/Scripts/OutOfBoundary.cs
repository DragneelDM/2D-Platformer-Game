using UnityEngine;

public class OutOfBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerController>()?.Death();
    }
}
