using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int HealthIncreaseValue = 50;
    public int WeaponDamageValue = 15;
    private GameObject _enemiesObject;

    private void Awake()
    {
        _enemiesObject = GameObject.Find("Enemies");
    }
    public void Healup(PlayerHealthSystem player)
    {
        player.Health += HealthIncreaseValue; 

    }
   public void ExtraDamage(GunScript gun)
    {
        gun.WeaponDamage += WeaponDamageValue;
    }
   public void BlindEnemy()
    {
        EnemyManager[] _enemies = _enemiesObject.GetComponentsInChildren<EnemyManager>();
        foreach (var enemy in _enemies)
        {
            enemy.IsBlind = true;
        }
    }
}
