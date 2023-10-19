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
    [SerializeField] private AudioClip _audioClip;
    [Space(5)]
    [Header("Debug Weapon")]
    [SerializeField] private bool _isPlayerOwned;
    private bool canFire = true;
    private float fireTimer = 0f;
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
        _audioClip = _WeaponOptions.WeaponData.WeaponSound;
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
            UIManager.instance.UpdateAmmo(WeaponCurrentAmmo, WeaponMagazineSize);
            if (canFire && Input.GetButtonDown("Fire1") && WeaponCurrentAmmo > 0)
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
        WeaponCurrentAmmo--;
        canFire = false;
        if (_Muzzle != null)
        {
            // Instantiate(_particleEffect, _Muzzle.position, _Muzzle.rotation);
            //AudioSource.PlayClipAtPoint(_audioClip, _Muzzle.position);
           
        }
    }
}
