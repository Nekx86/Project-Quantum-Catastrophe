using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public int Health = 100;

    public AudioClip HurtSound;

    private void Update()
    {
        UIManager.instance.UpdateHealth(Health);
        if (Health <= 0)
        {
            Die();
        }
        if (Health > 100)
        {
            Health = 100;
        }
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    public void Die()
    {
     

    }
}
