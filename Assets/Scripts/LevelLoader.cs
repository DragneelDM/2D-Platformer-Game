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
                SoundManager.Instance.Play(Sounds.ButtonClick);
                print("New Homework Unlocked");
            break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                print("Get Lost");
            break;
        }
    }
}