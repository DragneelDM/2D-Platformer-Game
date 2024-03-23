using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<PlayerController>()?.Death();
    }
}
