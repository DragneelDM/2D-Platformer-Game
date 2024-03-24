using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    // Scene Values
    private int _totalKeys = 0;
    private int _currentKey = 0;
    private int _currentHealth = 3;
    public bool DoorLocked { get; private set; } = false;
    [SerializeField] private Transform _healthLayout;
    [SerializeField] private Transform _keyLayout;

    // Prefabs
    [SerializeField] private GameObject _keyUi;
    [SerializeField] private GameObject _health;
    [SerializeField] public BossUI BossUi;
    private Gunner _boss;

    // Collection
    private List<GameObject> _healthBars = new List<GameObject>();
    private Dictionary<int, GameObject> _keys = new Dictionary<int, GameObject>();
    private List<TutorialGuide> _tutorialGuides = new List<TutorialGuide>();


    private PlayerController playerController;
    public PlayerController PlayerController { get { return playerController; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += Init;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= Init;
    }

    private void Init(Scene scene, LoadSceneMode mode)
    {
        int currentScene = scene.buildIndex;
        GameObject player = Instantiate(LevelManager.Instance.getPlayerPrefab(currentScene));
        playerController = player.GetComponent<PlayerController>();

        ResetUI();

        for (int iteration = 0; iteration < _currentHealth; iteration++)
        {
            GameObject temp = Instantiate(_health, _healthLayout);
            _healthBars.Add(temp);
        }

    }

    public void ResetUI()
    {
        foreach (GameObject healthBar in _healthBars)
        {
            Destroy(healthBar);
        }
        _healthBars.Clear();

        foreach (KeyValuePair<int, GameObject> keyEntry in _keys)
        {
            Destroy(keyEntry.Value);
        }
        _keys.Clear();

        _currentKey = 0;
        _totalKeys = 0;
    }

    #region Dictionary
    public void SetKey()
    {
        _totalKeys++;
    }

    public Animator GetKey(int key)
    {
        if (_keys.ContainsKey(key))
        {
            return _keys[key].GetComponentInChildren<Animator>();
        }
        else
        {
            Debug.LogWarning("Key not found in the dictionary: " + key);
            return null;
        }
    }

    public void SetGuide(TutorialGuide tutorialGuide)
    {
        _tutorialGuides.Add(tutorialGuide);
    }

    #endregion

    public void InitKeys()
    {
        for (int iteration = 0; iteration < _totalKeys; iteration++)
        {
            GameObject temp = Instantiate(_keyUi, _keyLayout);
            _keys.Add(iteration, temp);
        }
    }

    public void ReduceHealth()
    {

        if (_currentHealth - 1 > 0)
        {
            _healthBars[_currentHealth - 1].GetComponentInChildren<Animator>().SetBool(StringConsts.Blast, true);
            _currentHealth--;
        }
        else
        {
            SceneManager.LoadScene(StringConsts.End);
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public void IncreaseKey()
    {
        GetKey(_currentKey).SetBool(StringConsts.KeyBurst, true);
        GetKey(_currentKey).SetBool(StringConsts.Reset, false);
        _currentKey++;
        // Open Door After Collecting Everything
        DoorLocked = _currentKey == _keys.Count;

        // Update Tutorial
        if(DoorLocked)
        {
            foreach (TutorialGuide guide in _tutorialGuides)
            {
                guide.KeyTaken();
            }
        }
    }

    public void SetBoss(Gunner gunner)
    {
        _boss = gunner;
        BossUi.SetBoss(_boss.GetComponent<Animator>());
    }

    public void Won()
    {
        _healthLayout.gameObject.SetActive(false);
        BossUi.gameObject.SetActive(false);
        LevelManager.Instance.ChangeScene(Levels.Win.ToString());
    }
}
