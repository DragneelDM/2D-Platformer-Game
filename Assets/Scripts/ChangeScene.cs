using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField, Range(0,10)] int SceneIndex;
    private void Start() {
        if(button != null)
            button.onClick.AddListener(Play);
    }
    public void Play(){
        SceneManager.LoadScene(SceneIndex);
    }
}
