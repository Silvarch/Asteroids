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


    private double SecondsBetweenSpawns = 5;
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

        
            int SpawnDecider = Randomize();
            NextSpawnTime = Time.time + SecondsBetweenSpawns;
            Vector2 SpawnPosition = new Vector2(Random.Range(-ScreenHalfSizeWorldUnits.x, ScreenHalfSizeWorldUnits.x), ScreenHalfSizeWorldUnits.y);

           
        //switch statement set up so that large asteroid objects are half as likely to spawn as regular sized ones
        switch (SpawnDecider)
        {
            case 1:
            case 2:
                Instantiate(AsteroidMovementPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 3:
            case 4:
                Instantiate(AsteroidRightMovementPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 5:
            case 6:
                Instantiate(AsteroidLeftMovementPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 7:
                Instantiate(HugeAsteroidMovementPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 8:
                Instantiate(HugeAsteroidLeftMovementPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 9:
                Instantiate(HugeAsteroidRightMovementPrefab, SpawnPosition, Quaternion.identity);
                break;
        }

        if (SecondsBetweenSpawns > 2)
        {

            for (int i = 10; i < Time.time; i += 10)
            {
                SecondsBetweenSpawns -= .1;
            }
        }
                
    }

    int Randomize()
    {
        int RandomInteger = Random.Range(1, 10);
        return RandomInteger;
    }


    /*Written by LL */
}
