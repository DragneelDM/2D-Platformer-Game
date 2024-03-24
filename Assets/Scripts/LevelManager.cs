using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    [SerializeField] private PlayerData[] playerPrefabs;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        return (LevelStatus)PlayerPrefs.GetInt(level, 0);
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }

    public GameObject getPlayerPrefab(int level)
    {
        PlayerData player = Array.Find(playerPrefabs, value => (int)value.level == level);
        return player?.player;
    }

    public void ChangeScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

[Serializable]
public class PlayerData
{
    public GameObject player;
    public Levels level;
}

public enum Levels
{
    Lobby,
    LevelSelector,
    Level1,
    Level2,
    Level3,
    Level4,
    End,
    Win
}