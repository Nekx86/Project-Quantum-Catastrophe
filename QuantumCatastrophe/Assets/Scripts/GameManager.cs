using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Enemies;
    private int _currentLevelIndex = 0;
    private int _needkill; // Sonraki level için gerekli kill sayýsý 
    private int _playerkill;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _needkill = Enemies.transform.childCount;
        _playerkill = 0;
    }
    [SerializeField] int EnemyCount;
    private void UpdateEnemyCount()
    {
        EnemyCount = Enemies.transform.childCount;
    }
    public int OneEnemyDown()
    {
      return _playerkill += 1;
    }
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (_playerkill >= _needkill)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Þartlar Karþýlanmadý!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyCount();
        UIManager.instance.UpdateEnemyCount(EnemyCount);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.instance.CheckPause())
            {
                UIManager.instance._showPauseMenu();
            }
            else
            {
                UIManager.instance.ShowPauseMenu();
            }
        }
    }
}
