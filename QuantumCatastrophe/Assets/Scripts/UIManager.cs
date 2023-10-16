using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    public RawImage Crosshair;
    public void Crosshair_DetechPickableObject(bool _isdetected)
    {
      
        if (_isdetected)  { Crosshair.color = Color.red;}
        else { Crosshair.color = Color.white;}
    }
}
