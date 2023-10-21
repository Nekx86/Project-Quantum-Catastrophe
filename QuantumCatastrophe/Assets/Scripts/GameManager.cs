using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Enemies;
    public GameObject Player;
    private static int _currentLevelIndex = 0;
    private int _needkill; // Sonraki level için gerekli kill sayýsý 
    public int Playerkill;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
          
        }
       
    }
    private void Start()
    {
        AudioManager.instance.PlayBG();
        Time.timeScale = 1;
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        _needkill = Enemies.transform.childCount;
        Playerkill = 0;
    }
    [SerializeField] int EnemyCount;
    private void UpdateEnemyCount()
    {
        EnemyCount = Enemies.transform.childCount;
       
    }
    public int OneEnemyDown()
    {
      return Playerkill += 1;
    }
    public static void RestartLevel()
    {

        SceneManager.LoadScene(_currentLevelIndex);

    }
   private bool IsLastLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        return currentSceneIndex == lastSceneIndex;
    }
    public void NextLevel()
    {

        int nextSceneIndex = _currentLevelIndex + 1;
        
        if (Playerkill >= _needkill)
        {
            if (IsLastLevel())
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            
        }
        else
        {
            Debug.Log("Þartlar Karþýlanmadý!");
        }
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Level0");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateEnemyCount();
        UIManager.instance.UpdateEnemyCount(EnemyCount);
        if (EnemyCount <= 0)
        {
            UIManager.instance.ShowWinMenu();
            Player.GetComponent<PlayerCameraController>().enabled = false;
         
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.instance.CheckPause())
            {
                UIManager.instance._showPauseMenu();
                Player.GetComponent<PlayerCameraController>().enabled = true;
            }
            else
            {
                UIManager.instance.ShowPauseMenu();
                Player.GetComponent<PlayerCameraController>().enabled = false;
            }
        }
    }
}
