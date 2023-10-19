
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<ItemScriptableObject> SpawnableObjects;
    public float SpawnInterval = 15f;
    [HideInInspector] public string ItemType;
    [HideInInspector] public int CountSize;
  [HideInInspector] public GameObject CurrentObject;
    private float _spawnTimer;
    private bool _isObjectTaken = false;
    [SerializeField] private Transform _transform;
    private void Awake()
    {
        _transform = this.gameObject.transform.GetChild(2).transform;
    }
    private void Update()
    {
        if (CurrentObject == null || _isObjectTaken)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= SpawnInterval)
            {
                SpawnObject();
                _spawnTimer = 0f;
                _isObjectTaken = false;
            }
        }
    }

    private void SpawnObject()
    {
        int RandomIndex = Random.Range(0,SpawnableObjects.Count);
        GameObject objectToSpawn = SpawnableObjects[RandomIndex].ItemPrefab;
        CurrentObject = Instantiate(objectToSpawn, _transform.position, Quaternion.identity);
        CurrentObject.transform.SetParent(_transform.transform);
        CurrentObject.AddComponent<WeaponSpawnAnimation>();
        CurrentObject.AddComponent<ItemRotationAnimation>();
        ItemType = SpawnableObjects[RandomIndex].ItemGroup.ToString();
        CountSize = SpawnableObjects[RandomIndex].ItemCount;
        AddCustomComponent(SpawnableObjects[RandomIndex].ItemGroup);

    }
    private void AddCustomComponent(ItemScriptableObject.ItemType ItemBase)
    {
        if (ItemBase == ItemScriptableObject.ItemType.Weapons)
        {
            CurrentObject.AddComponent<GunScript>();
        }
        else if (ItemBase == ItemScriptableObject.ItemType.Powers)
        {
            
        }
        else if (ItemBase == ItemScriptableObject.ItemType.ConsumableItems)
        {
            CurrentObject.AddComponent<AmmoBox>();
            CurrentObject.GetComponent<AmmoBox>().AmmoCount = CountSize;
        }
    }
    public void ObjectTaken()
    {
        _isObjectTaken = true;
        Destroy(CurrentObject.gameObject);
        StartCoroutine(RespawnObject());
    }
    IEnumerator RespawnObject()
    {
        yield return new WaitForSeconds(SpawnInterval);

        if (_isObjectTaken)
        {
            SpawnObject();
            _isObjectTaken = false;
        }
    }
}
