using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public float Distance = 3f;
    public LayerMask mask;
    public GameObject UManager;
    private UIManager _uManager;
    public List<string> tagFields;
    private bool _isDetected = false;
    private void Awake()
    {
        _uManager= UManager.GetComponent<UIManager>();
    }
    private void Update()
    {
       RaycastHit hit;
       Camera camera = Camera.main;
        Vector3 RayOrigin = camera.transform.position;
        Vector3 RayDirection = camera.transform.forward;
        
        if (Physics.Raycast(RayOrigin,RayDirection,out hit,Distance,mask))
        {
            foreach (var item in tagFields)
            {
                if (hit.collider.CompareTag(item))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponentInParent<SpawnManager>().ObjectTaken();
                        
                    }
                   _isDetected = true;
                }  
            }
        }
        else
        {
            _isDetected = false;
        }
        _uManager.Crosshair_DetechPickableObject(this._isDetected);
    }
   
    private void OnDrawGizmos()
    {
       
    }
}
