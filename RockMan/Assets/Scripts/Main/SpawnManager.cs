using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyObj;
    private float spawnRangeMin = 10;
    private float spawnRangeMax = 90;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        float spawnPositionX = Random.Range(spawnRangeMin, spawnRangeMax);
        Vector3 spawnPosition = new Vector3(spawnPositionX, 1.5f, 0);
        Instantiate(enemyObj, spawnPosition, Quaternion.identity);
    }
  
}
