using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            print("Try Again");

            SceneManager.LoadScene(
                SceneManager.GetActiveScene( ).buildIndex
            );
        }
    }
}
