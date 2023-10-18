using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.UIElements;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public float Distance = 3f;
    public LayerMask mask;
    public GameObject UManager;
    public Transform[] Arms;
    private UIManager _uManager;
    public List<string> tagFields;
    private bool _isDetected = false;
    private GameObject _TakeObject;
    private void Awake()
    {
        _uManager = UManager.GetComponent<UIManager>();
    }
    public void InstantiateWeapon(GameObject obj, Transform arm)
    {
        if (arm.childCount > 0)
        {
            Destroy(arm.transform.GetChild(0).gameObject);
        }
        GameObject ob = Instantiate(obj, arm.position, Quaternion.identity);
        ob.transform.SetParent(arm);

       
        ob.transform.localRotation = Quaternion.identity;

      
        ob.transform.localPosition = Vector3.zero;

     
        WeaponSpawnAnimation weaponSpawnAnim = ob.GetComponent<WeaponSpawnAnimation>();
        if (weaponSpawnAnim != null)
        {
            Destroy(weaponSpawnAnim);
        }

       
        ItemRotationAnimation itemRotationAnim = ob.GetComponent<ItemRotationAnimation>();
        if (itemRotationAnim != null)
        {
            Destroy(itemRotationAnim);
        }
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
                        _TakeObject = hit.collider.gameObject.GetComponentInParent<SpawnManager>().CurrentObject;
                        string _type = hit.collider.gameObject.GetComponentInParent<SpawnManager>().ItemType;
                        string _weapontype = _TakeObject.GetComponent<GunData>().WeaponData.Type.ToString();
                        
                        if (_type == ItemScriptableObject.ItemType.Weapons.ToString())
                        {
                          
                            if (_weapontype == ScriptableObject_WeaponsFeature.WeaponType.Pistol.ToString())
                            {
                                InstantiateWeapon(_TakeObject, Arms[0]);
                                
                            }
                            else if (_weapontype == ScriptableObject_WeaponsFeature.WeaponType.Rifle.ToString())
                            {
                                InstantiateWeapon(_TakeObject, Arms[1]);
                            }
                            else if (_weapontype == ScriptableObject_WeaponsFeature.WeaponType.Shotgun.ToString())
                            {
                                InstantiateWeapon(_TakeObject, Arms[2]);
                            }
                        }
                        else if (_type == ItemScriptableObject.ItemType.Powers.ToString())
                        {

                        }
                        else if (_type == ItemScriptableObject.ItemType.ConsumableItems.ToString())
                        {

                        }
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
