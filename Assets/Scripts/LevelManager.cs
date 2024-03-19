using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;
    public static LevelManager Instance { get { return instance; }}

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    public LevelStatus GetLevelStatus(string level){
        return (LevelStatus) PlayerPrefs.GetInt(level, 0);
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus){
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
