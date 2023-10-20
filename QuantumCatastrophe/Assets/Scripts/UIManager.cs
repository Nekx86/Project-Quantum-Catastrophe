using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public RawImage Crosshair;
    public TMP_Text AmmoText, HealthText, EnemyCountText;
    private int _currentIndex = 0;
    public TMP_Text[] ArmSlots;
    public GameObject pauseMenu;
    public float animationDuration = 0.5f;
    private bool _isPaused = false;
    void Awake()
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
    public void UpdateArmUI(int newIndex)
    {
        ArmSlots[_currentIndex].color = Color.white;
        ArmSlots[newIndex].color = Color.yellow;
        _currentIndex = newIndex;
    }
    public bool CheckPause()
    {
        if (_isPaused)
        {
            return true;
        }
        return false;
    }
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    public void Crosshair_DetechPickableObject(bool _isdetected)
    {
        if (_isdetected) { Crosshair.color = Color.red; }
        else { Crosshair.color = Color.white; }
    }
    public void ShowPauseMenu()
    {
        Time.timeScale = 0;
        _isPaused = true;
        pauseMenu.SetActive(true);
        pauseMenu.transform.localScale = Vector3.one;
        pauseMenu.transform.DOScale(new Vector3 (20,20), animationDuration);
       UnlockMouseCursor();
    }
    private void LockMouseCursor()
    {
        Crosshair.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockMouseCursor()
    {
        Crosshair.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void _showPauseMenu()
    {
        _isPaused = false;
        Time.timeScale = 1;
        pauseMenu.transform.DOScale(Vector3.zero, animationDuration).OnComplete(() =>
        {
            pauseMenu.SetActive(false);
        });
        LockMouseCursor();
        
    }
    public void UpdateHealth(int Health)
    {
        HealthText.text = "%" + Health;
    }
    public void UpdateAmmo(int CurrentAmmo, int MagazineSize)
    {
        AmmoText.text = $"{CurrentAmmo} / {MagazineSize}";
    }
    public void UpdateEnemyCount(int EnemyCount)
    {
        EnemyCountText.text = $"Enemy Remaining: {EnemyCount}";
    }
}
