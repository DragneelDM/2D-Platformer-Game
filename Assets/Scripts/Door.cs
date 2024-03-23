using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] string NextScene;
    BoxCollider2D myCollider;

    private void Start() {
        myCollider = GetComponent<BoxCollider2D>();
    }

    public void OpenSesame() {
        myCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
        LevelManager.Instance.SetLevelStatus(NextScene, LevelStatus.Unlocked);
        SceneManager.LoadScene(NextScene);
    }
}
