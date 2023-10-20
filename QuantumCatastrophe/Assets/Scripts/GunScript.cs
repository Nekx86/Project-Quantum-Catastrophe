using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private GunData _WeaponOptions;
    [Header("Weapon Settings")]
    [SerializeField] private Transform _Muzzle;
    [SerializeField] private GameObject _particleEffect;
    [Header("Weapon Data")]
    public int WeaponDamage;
    public float WeaponFireRate;
    public int WeaponMagazineSize;
    public int WeaponCurrentAmmo;
    public int MaxClipAmmo;
    [Header("Weapon Sound")]
    [SerializeField] private AudioClip _audioClip_Shoot;
    [SerializeField] private AudioClip _audioClip_Reload;
   
    [Space(5)]
    [Header("Debug Weapon")]
    [SerializeField] private bool _isPlayerOwned;
    private bool canFire = true;
    private float fireTimer = 0f;
   [SerializeField] private GameObject _targetEnemy;
    private void Awake()
    {

        _WeaponOptions = GetComponent<GunData>();
        this.gameObject.name = _WeaponOptions.WeaponData.WeaponName;
        WeaponDamage = _WeaponOptions.WeaponData.Damage;
        MaxClipAmmo = _WeaponOptions.WeaponData.AvailableAmmo;
        WeaponFireRate = _WeaponOptions.WeaponData.FireRate;
        WeaponMagazineSize = _WeaponOptions.WeaponData.MagazineSize;
        WeaponCurrentAmmo = _WeaponOptions.WeaponData.CurrentAmmo;
        _particleEffect = _WeaponOptions.WeaponData.ParticleEffect;
        _audioClip_Shoot = _WeaponOptions.WeaponData.WeaponSound;
        _audioClip_Reload = _WeaponOptions.WeaponData.WeaponSound_Reload;
        _Muzzle = this.gameObject.transform.GetChild(1).transform;


    }
    public void EnableFire()
    {
        _isPlayerOwned = true;
      
    }
    private void Update()
    {
        if (_isPlayerOwned)
        {
            RaycastHit hit;
            Camera camera = Camera.main;
            Vector3 RayOrigin = camera.transform.position;
            Vector3 RayDirection = camera.transform.forward;

            if (Physics.Raycast(RayOrigin, RayDirection, out hit, _WeaponOptions.WeaponData.Range))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy Found");
                    _targetEnemy = hit.collider.gameObject;
                }
                else
                {
                    _targetEnemy = null;
                }
              
            }
            UIManager.instance.UpdateAmmo(WeaponCurrentAmmo, WeaponMagazineSize);
            if (canFire && Input.GetButton("Fire1") && WeaponCurrentAmmo > 0)
            {
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.R) && WeaponCurrentAmmo < MaxClipAmmo)
            {
                Reload();
            }
            if (!canFire)
            {
                fireTimer += Time.deltaTime;
                if (fireTimer >= 1f / WeaponFireRate)
                {
                    canFire = true;
                    fireTimer = 0f;
                }
            }
        }
    }
    private void Reload()
    {
        AudioManager.instance.PlaySound(_audioClip_Reload);
        int bulletsToReload = MaxClipAmmo - WeaponCurrentAmmo;
        int bulletsAvailable = Mathf.Min(bulletsToReload, WeaponMagazineSize);

        if (bulletsAvailable > 0)
        {
            WeaponCurrentAmmo += bulletsAvailable;
            WeaponMagazineSize -= bulletsAvailable;
        }

    }
  
    private void Shoot()
    {
        AudioManager.instance.PlaySound(_audioClip_Shoot);
        WeaponCurrentAmmo--;
        if (_targetEnemy != null)
        {
            _targetEnemy.GetComponent<EnemyManager>().TakeDamage(WeaponDamage);
           
        }

        canFire = false;

         
    }
}
