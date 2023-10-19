using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int HealthIncreaseValue = 50;
    public int WeaponDamageValue = 15;
    public void Healup(PlayerHealthSystem player)
    {
        player.Health += HealthIncreaseValue; 

    }
   public void ExtraDamage(GunScript gun)
    {
        gun.WeaponDamage += WeaponDamageValue;
    }
   public void BlindEnemy(EnemyManager enemyManager)
    {

    }
}
