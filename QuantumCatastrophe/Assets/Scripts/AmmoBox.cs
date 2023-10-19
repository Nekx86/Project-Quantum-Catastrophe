using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int AmmoCount = 0;
    public void AmmoGive(Transform transform)
    {
       
        GunScript[] gunScripts = transform.GetComponentsInChildren<GunScript>();
        foreach (var Gunscript in gunScripts)
        {
            Gunscript.WeaponMagazineSize += AmmoCount;
        }

    }

}
