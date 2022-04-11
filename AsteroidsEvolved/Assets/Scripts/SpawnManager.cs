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
    public GameObject ParticleSystemPrefab;
    public GameObject HugeParticleSystemPrefab;

    private double SecondsBetweenSpawns = 5;//starting time between spawns, used to calculate next spawn time
    double NextSpawnTime; //Sets the gametime when another asteroid will spawn
    public float speed = 2; //Controls the speed that all asteroids fall at
    public static string AsteroidType; //Used to encapsulate each asteroid spawned into a category based on the direction it falls in. hels with trail creation


    Vector2 ScreenHalfSizeWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        ScreenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.timeSinceLevelLoad > NextSpawnTime)
        {
            
            Spawn();
            

        }
    }

    void Spawn()
    {

        
            int SpawnDecider = Randomize();
            NextSpawnTime = Time.timeSinceLevelLoad + SecondsBetweenSpawns;
            Vector2 SpawnPosition = new Vector2(Random.Range(-ScreenHalfSizeWorldUnits.x, ScreenHalfSizeWorldUnits.x), ScreenHalfSizeWorldUnits.y);

           
        //switch statement set up so that large asteroid objects are half as likely to spawn as regular sized ones
        switch (SpawnDecider)
        {
            case 1:
            case 2:
                Instantiate(AsteroidMovementPrefab, SpawnPosition, Quaternion.identity);
                AsteroidType = "Down";
                Instantiate(ParticleSystemPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 3:
            case 4:
                Instantiate(AsteroidRightMovementPrefab, SpawnPosition, Quaternion.identity);
                AsteroidType = "Right";
                Instantiate(ParticleSystemPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 5:
            case 6:
                Instantiate(AsteroidLeftMovementPrefab, SpawnPosition, Quaternion.identity);
                AsteroidType = "Left";
                Instantiate(ParticleSystemPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 7:
                Instantiate(HugeAsteroidMovementPrefab, SpawnPosition, Quaternion.identity);
                AsteroidType = "HugeDown";
                Instantiate(HugeParticleSystemPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 8:
                Instantiate(HugeAsteroidLeftMovementPrefab, SpawnPosition, Quaternion.identity);
                AsteroidType = "HugeLeft";
                Instantiate(HugeParticleSystemPrefab, SpawnPosition, Quaternion.identity);
                break;
            case 9:
                Instantiate(HugeAsteroidRightMovementPrefab, SpawnPosition, Quaternion.identity);
                AsteroidType = "HugeRight";
                Instantiate(HugeParticleSystemPrefab, SpawnPosition, Quaternion.identity);
                break;
        }

        if (SecondsBetweenSpawns > 1.5)
        {

            for (int i = 10; i < Time.timeSinceLevelLoad; i += 10)
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
