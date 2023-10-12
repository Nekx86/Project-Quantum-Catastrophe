using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnAnimation : MonoBehaviour
{
   
    public float frequency = 2f;
    public float amplitude = 0.2f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        transform.position = startPos + amplitude * Mathf.Sin(Time.time * frequency) * Vector3.up;

    }
}
