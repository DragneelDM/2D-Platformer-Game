using System;
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
                SoundManager.Instance.Play(Sounds.ButtonClick);
                print("Thambi you are locked");
                ChangeColor(Color.red);
            break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                print("New Homework Unlocked");
            break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                ChangeColor(Color.green);
                print("Get Lost");
            break;
        }
    }

    void ChangeColor(Color color){
        // ColorBlock is a Stupid Struct
        ColorBlock cb = button.colors;
        cb.pressedColor = color;
        button.colors = cb;
    }
}