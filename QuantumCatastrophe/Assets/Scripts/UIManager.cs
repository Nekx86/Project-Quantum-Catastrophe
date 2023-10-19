using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public RawImage Crosshair;
    public TMP_Text AmmoText, HealthText, EnemyCountText;
    private int _currentIndex = 0;
    public TMP_Text[] ArmSlots;
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
    public void Crosshair_DetechPickableObject(bool _isdetected)
    {
        if (_isdetected)  { Crosshair.color = Color.red;}
        else { Crosshair.color = Color.white;}
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
