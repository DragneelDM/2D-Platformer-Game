using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; }}

    // Scene Values
    Key[] keysInScene;
    int currentKey = 0;
    int currentHealth;

    // Prefabs
    [SerializeField] GameObject keyUi;
    [SerializeField] GameObject health;

    // Collection
    List<GameObject> healthBars =  new List<GameObject>();
    List<Animator> keys = new List<Animator>();


    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        // Setting up Health
        currentHealth = FindObjectOfType<PlayerController>().Health;
        for(int iteration = 0; iteration < currentHealth; iteration++){
            GameObject temp = Instantiate(health, transform.Find("HealthLayout"));
            healthBars.Add(temp);
        }

        // Setting up Keys
        keysInScene = FindObjectsOfType<Key>();
        foreach(Key key in keysInScene){
            GameObject temp = Instantiate(keyUi, transform.Find("KeyLayout"));
            keys.Add(temp.GetComponentInChildren<Animator>());
        }
    }

    public void ReduceHealth(){

        if(currentHealth - 1 > 0){
        healthBars[currentHealth - 1].GetComponentInChildren<Animator>().SetBool("Blast", true);
        currentHealth--;

        // Reset Keys
        currentKey = 0;
        foreach(Animator key in keys){
            key.SetBool("KeyBurst", false);
            key.SetBool("Reset", true);
        }
        } else
        {
            SceneManager.LoadScene("End");
            for(int i = 0; i < transform.childCount; i++){
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public void AddKey(){
            keys[currentKey].SetBool("KeyBurst", true);
            keys[currentKey].SetBool("Reset", false);
            currentKey++;

            // Open Door After Collecting Everything
            if(currentKey == keys.Count) { FindObjectOfType<Door>()?.OpenSesame();}
    }
}
