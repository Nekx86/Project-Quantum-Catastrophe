using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int MaxHealth = 100;
    public float CurrentHealth;
    public int Damage = 10;
    public float MissChance = 0.2f;
    public float MoveSpeed = 5.0f;
    public float FireRate = 2.0f;
    public float RotationSpeed = 2f;
    public GameObject Player;
    public float DetectionRange = 10f;
    public float ShootingRange = 5f;
    public bool IsBlind = false;
    public float BlindDuration = 5.0f;
    public AudioClip WeaponSound;
    public AudioClip EnemyHurtSound;
    public AudioClip EnemyDiedSound;
    private float _blindTimer = 0.0f;
    private bool _canSeePlayer = false;
    private float _nextFireTime = 0.0f;
    public float MaxChaseDistance = 3.0f;
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (IsBlind)
        {
            _blindTimer += Time.deltaTime;

            if (_blindTimer >= BlindDuration)
            {
                IsBlind = false;
                _blindTimer = 0.0f;
            }
        }

        CheckVisibility();
        if (!IsBlind)
        {
            HandleShooting();  
        }
    }

    public void HandleShooting()
    {
        if (_canSeePlayer)
        {
            RotateTowardsPlayer();
            if (Time.time >= _nextFireTime && Vector3.Distance(transform.position, Player.transform.position) <= ShootingRange)
            {
                AudioManager.instance.PlaySound(WeaponSound);
                if (Random.value > MissChance)
                {
                    Player.GetComponent<PlayerHealthSystem>().TakeDamage(Damage);
                }
                else
                {
                    Debug.Log("Düþman ýskaladý!");
                }

              
                _nextFireTime = Time.time + 1.0f / FireRate;
            }
        }
    }

    public void CheckVisibility()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer <= DetectionRange)
        {
            _canSeePlayer = true;
        }
        else
        {
            _canSeePlayer = false;
        }
    }

    public void TakeDamage(int amount)
    {
        AudioManager.instance.PlaySound(EnemyHurtSound);
        _canSeePlayer = true;
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            AudioManager.instance.PlaySound(EnemyDiedSound);
            Die();
        }
    }

    void Die()
    {
        
        GameManager.Instance.OneEnemyDown();
        Destroy(gameObject);
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = Player.transform.position - transform.position;
        direction.y = 0; 
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
        if (Vector3.Distance(transform.position, Player.transform.position) > MaxChaseDistance)
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
    }
}
