using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void reload(){
        SceneManager.LoadScene("TestScene");
    }

    public void Play(){
        FindObjectOfType<Image>().sprite = null;
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        Application.Quit();
    }
}
