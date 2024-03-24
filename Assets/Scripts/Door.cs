using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Levels _currentLevel;
    [SerializeField] private Levels _nextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.DoorLocked)
        {
            LevelManager.Instance.SetLevelStatus(_currentLevel.ToString(), LevelStatus.Completed);
            LevelManager.Instance.SetLevelStatus(_nextScene.ToString(), LevelStatus.Unlocked);
            GameManager.Instance.ResetUI();
            LevelManager.Instance.ChangeScene(_nextScene.ToString());
        }

    }
}
