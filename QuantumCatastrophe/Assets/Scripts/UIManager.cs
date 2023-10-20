using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Texts, Crosshair, etc")]
    public RawImage Crosshair;
    public TMP_Text AmmoText, HealthText, EnemyCountText,PlayerKillText;
    private int _currentIndex = 0;
    public TMP_Text[] ArmSlots;
    [Header("Menus")]
    public GameObject PauseMenu;
    public GameObject DieMenu;
    public GameObject WinMenu;
    [Header("Animation & Pause Check")]
    public float animationDuration = 2f;
    private bool _isPaused = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
           
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
        PauseMenu.SetActive(false);
    }
    public void Crosshair_DetechPickableObject(bool _isdetected)
    {
        if (_isdetected) { Crosshair.color = Color.red; }
        else { Crosshair.color = Color.white; }
    }
    public void ShowDieMenu()
    {
        UnlockMouseCursor();
        DieMenu.SetActive(true);
        PlayerKillText.text = $"Killed Enemies:{GameManager.Instance.Playerkill}";
        Time.timeScale = 0;
        DieMenu.transform.localScale = Vector3.one;
        DieMenu.transform.DOScale(Vector3.one, animationDuration);
    }
    public void ShowWinMenu()
    {
        UnlockMouseCursor();
        WinMenu.SetActive(true);
        Time.timeScale = 0;
        WinMenu.transform.localScale = Vector3.one;
        WinMenu.transform.DOScale(Vector3.one, animationDuration);
    }
    public void ShowPauseMenu()
    {
        Time.timeScale = 0;
        _isPaused = true;
        PauseMenu.SetActive(true);
        PauseMenu.transform.localScale = Vector3.one;
        PauseMenu.transform.DOScale(Vector3.one, animationDuration);
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
        PauseMenu.transform.DOScale(Vector3.zero, animationDuration).OnComplete(() =>
        {
            PauseMenu.SetActive(false);
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
