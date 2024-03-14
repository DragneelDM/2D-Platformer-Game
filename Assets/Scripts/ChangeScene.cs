using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField, Range(0,10)] int SceneIndex;
    public void Play(){
        SceneManager.LoadScene(SceneIndex);
    }
}
