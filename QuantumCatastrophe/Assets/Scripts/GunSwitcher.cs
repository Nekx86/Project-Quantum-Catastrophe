using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject[] Slots;
    private int _currentIndex = 0;
    void Start()
    {
        SwitchGun(_currentIndex);
    }

    private void SwitchGun(int newIndex)
    {
        if (IsAnyWeapon(newIndex))
        {
            Slots[_currentIndex].SetActive(false);
            Slots[newIndex].SetActive(true);
            _currentIndex = newIndex;
        }
        else
        {
            Debug.Log("Herhangi bir silah bulamadým!");
        }
    }
    bool IsAnyWeapon(int index)
    {
        if (Slots[index].transform.childCount > 0)
        {
            return true;
        }
        else { return false; }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchGun(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchGun(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            SwitchGun(2);
        }
    }
}
