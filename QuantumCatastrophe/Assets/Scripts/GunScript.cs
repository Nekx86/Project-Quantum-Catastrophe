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
    [Header("Weapon Sound")]
    [SerializeField] private AudioClip _audioClip;
    [Space(5)]
    [Header("Debug Weapon")]
    [SerializeField] private bool _isPlayerOwned;
    private void Awake()
    {
      
        _WeaponOptions = GetComponent<GunData>();
        this.gameObject.name = _WeaponOptions.WeaponData.WeaponName;
        WeaponDamage = _WeaponOptions.WeaponData.Damage;
        WeaponFireRate = _WeaponOptions.WeaponData.FireRate;
        WeaponMagazineSize = _WeaponOptions.WeaponData.MagazineSize;
        WeaponCurrentAmmo = _WeaponOptions.WeaponData.CurrentAmmo;
        _particleEffect = _WeaponOptions.WeaponData.ParticleEffect;
        _audioClip = _WeaponOptions.WeaponData.WeaponSound;
        _Muzzle = this.gameObject.transform.GetChild(1).transform;
       

    }
    private void Update()
    {
        if (_isPlayerOwned)
        {
            
        }
    }
}
