using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour {
    Button button;
    public string LevelName;

    private void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick(){
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);

        switch(levelStatus){
            case LevelStatus.Locked:
                print("Thambi you are locked");
            break;
            case LevelStatus.Unlocked:
                print("New Homework Unlocked");
            break;
            case LevelStatus.Completed:
                print("Get Lost");
            break;
        }
    }
}