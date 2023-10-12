using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Quantum Weapon Tool",menuName ="QuantumTools/Create a Weapon Object")]
public class ScriptableObject_WeaponsFeature : ScriptableObject
{
    public enum WeaponType
    {
        Pistol,
        Shotgun,
        Rifle
    }
    public string WeaponName;
    public int Damage;
    public float FireRate;
    public int MagazineSize;
    public int CurrentAmmo;
    public float Range;
    public WeaponType Type;
}
