using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] int EnemyCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.instance.UpdateEnemyCount(EnemyCount);
    }
}
