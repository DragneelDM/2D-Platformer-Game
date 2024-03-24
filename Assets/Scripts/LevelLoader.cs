using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button _button;

    public void OnClick(string levelName)
    {
        if (levelName == "Quit") { Application.Quit(); }

        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

        switch (levelStatus)
        {
            case LevelStatus.Locked:
                ChangeColor(Color.red);
                SoundManager.Instance.Play(Sounds.ButtonClick);
                break;
            case LevelStatus.Unlocked:
                ChangeColor(Color.magenta);
                SoundManager.Instance.Play(Sounds.ButtonClick);
                LevelManager.Instance.ChangeScene(levelName);
                break;
            case LevelStatus.Completed:
                ChangeColor(Color.green);
                SoundManager.Instance.Play(Sounds.ButtonClick);
                LevelManager.Instance.ChangeScene(levelName);
                break;
        }
    }

    private void ChangeColor(Color color)
    {
        // ColorBlock is a Struct. Couldn't edit a variable without making a copy
        ColorBlock cb = _button.colors;
        cb.pressedColor = color;
        _button.colors = cb;
    }

    public void ToLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Destroy(GameManager.Instance.gameObject);
        Destroy(LevelManager.Instance.gameObject);
        Destroy(SoundManager.Instance.gameObject);
        LevelManager.Instance.ChangeScene(Levels.Lobby.ToString());
    }
}