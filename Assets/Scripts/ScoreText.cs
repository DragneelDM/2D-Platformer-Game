using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text ScoreObj;
    private int _score;
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    void Start() {
        ScoreObj = GetComponent<Text>();
        RefreshUI();
    }

    public void IncreaseScore(int num){
        Score += num;
        RefreshUI();
    }

    void RefreshUI(){
        ScoreObj.text = "Score: " + Score.ToString();
    }
}
