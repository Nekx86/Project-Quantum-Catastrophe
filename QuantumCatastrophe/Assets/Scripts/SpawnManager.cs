
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<ItemScriptableObject> SpawnableObjects;
    public float SpawnInterval = 15f;
   [SerializeField] private GameObject _currentObject;
    private float _spawnTimer;
    private bool _isObjectTaken = false;
    [SerializeField] private Transform _transform;
    private void Awake()
    {
        Debug.Log(this.gameObject.transform.GetChild(2).name);
        _transform = this.gameObject.transform.GetChild(2).transform;
    }
    private void Update()
    {
        if (_currentObject == null || _isObjectTaken)
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
        _currentObject = Instantiate(objectToSpawn, _transform.position, Quaternion.identity);
        _currentObject.transform.SetParent(_transform.transform);
        _currentObject.AddComponent<WeaponSpawnAnimation>();
        _currentObject.AddComponent<ItemRotationAnimation>();

    }
    public void ObjectTaken()
    {
        _isObjectTaken = true; 
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
