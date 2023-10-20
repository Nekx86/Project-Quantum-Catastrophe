using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public int damage = 10;
    public float missChance = 0.2f;
    public float fireRate = 2.0f;
    public float RotationSpeed = 2f;
    public Transform player;
    public float detectionRange = 10f;
    public float shootingRange = 5f;
    public bool isBlind = false;
    public float blindDuration = 5.0f;
    private float blindTimer = 0.0f;
    private bool canSeePlayer = false;
    private float nextFireTime = 0.0f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (isBlind)
        {
            blindTimer += Time.deltaTime;

            if (blindTimer >= blindDuration)
            {
                isBlind = false;
                blindTimer = 0.0f;
            }
        }

        CheckVisibility();
        if (!isBlind)
        {
            HandleShooting();  
        }
    }

    public void HandleShooting()
    {
        if (canSeePlayer)
        {
            RotateTowardsPlayer();
            if (Time.time >= nextFireTime && Vector3.Distance(transform.position, player.position) <= shootingRange)
            {
                if (Random.value > missChance)
                {
                    player.GetComponent<PlayerHealthSystem>().TakeDamage(damage);
                }
                else
                {
                    Debug.Log("Düþman ýskaladý!");
                }

              
                nextFireTime = Time.time + 1.0f / fireRate;
            }
        }
    }

    public void CheckVisibility()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            canSeePlayer = true;
        }
        else
        {
            canSeePlayer = false;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0; 
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed); 
    }
}
