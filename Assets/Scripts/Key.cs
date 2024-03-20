using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){

            // Direct reference to Score because i am lazy
            FindObjectOfType<ScoreText>()?.IncreaseScore(1);
            Destroy(gameObject);
        }
    }
}
