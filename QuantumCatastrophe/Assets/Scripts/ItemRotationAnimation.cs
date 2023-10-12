using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotationAnimation : MonoBehaviour
{
    public float RotationSpeed = 50f;
    private void Update()
    {
        transform.Rotate(Vector3.up,RotationSpeed*Time.deltaTime);
    }
}
