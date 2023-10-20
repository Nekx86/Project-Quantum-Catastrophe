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
       
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
        if (Health > 100)
        {
            Health = 100;
        }
        UIManager.instance.UpdateHealth(Health);
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    public void Die()
    {
        this.gameObject.GetComponent<PlayerCameraController>().enabled = false;
        UIManager.instance.ShowDieMenu();
    }
}
