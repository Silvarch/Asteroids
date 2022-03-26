using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /* Written by LL */
    public GameObject AsteroidMovementPrefab;
    public GameObject AsteroidRightMovementPrefab;
    public GameObject AsteroidLeftMovementPrefab;
    public GameObject HugeAsteroidMovementPrefab;
    public GameObject HugeAsteroidRightMovementPrefab;
    public GameObject HugeAsteroidLeftMovementPrefab;


    private double SecondsBetweenSpawns = 3;
    double NextSpawnTime;

    Vector2 ScreenHalfSizeWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        ScreenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > NextSpawnTime)
        {
            
            Spawn();
            

        }
    }

    void Spawn()
    {
        for (int i = 10; i < NextSpawnTime; i += 10)
        {
            int SpawnDecider = Randomize();
            NextSpawnTime = Time.time + SecondsBetweenSpawns;
            Vector2 SpawnPosition = new Vector2(Random.Range(-ScreenHalfSizeWorldUnits.x, ScreenHalfSizeWorldUnits.x), ScreenHalfSizeWorldUnits.y);
        
            if (SpawnDecider == 1)
            {
                Instantiate(AsteroidMovementPrefab, SpawnPosition, Quaternion.identity);
            }
            else if (SpawnDecider == 2)
            {
                Instantiate(AsteroidRightMovementPrefab, SpawnPosition, Quaternion.identity);
            }
            else if (SpawnDecider == 3)
            {
                Instantiate(AsteroidLeftMovementPrefab, SpawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(HugeAsteroidMovementPrefab, SpawnPosition, Quaternion.identity);
            }
        }
            
        
    }

    int Randomize()
    {
        int RandomInteger = Random.Range(1, 4);
        return RandomInteger;
    }


    /*Written by LL */
}
