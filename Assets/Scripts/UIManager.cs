using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void reload(){
        SceneManager.LoadScene("TestScene");
    }

    public void Exit(){
        Application.Quit();
    }
}
