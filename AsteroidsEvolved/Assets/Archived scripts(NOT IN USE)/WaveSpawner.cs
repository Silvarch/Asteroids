using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Written by LL */
public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, IDLE, COUNTING };
    
    public Wave[] Waves;
    private int NextWave = 0;

    public float TimeBetweenWaves = 5;
    public float WaveCountdown;

    private float SearchFrequency = 1;

    private SpawnState State = SpawnState.COUNTING;

    void GameStart()
    {
        WaveCountdown = TimeBetweenWaves;
    }

    void Update()
    {
        if (State == SpawnState.IDLE)
        {
            if(!AsteroidsExist())
            {
                //Begin New Wave
                Debug.Log("Wave Completed");
                
            }
            else
            {
                return;
            }
        }

        if(WaveCountdown <= 0)
        {
            if(State != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(Waves[NextWave]));
                NextWave++;
            }
        }
        else
        {
            WaveCountdown -= Time.deltaTime;
        }
    }

    bool AsteroidsExist()
    {
        SearchFrequency -= Time.deltaTime;

        if (SearchFrequency <= 0f) // this limits how frequently a serach is performed to reduce program load
        {
            SearchFrequency = 1f;
            if (GameObject.FindGameObjectWithTag("Asteroid") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave Wave)
    {
        Debug.Log("Spawning Wave" + Wave.Count);
        State = SpawnState.SPAWNING;

        for (int i = 0; i < Wave.Count; i++)
        {
            SpawnAsteroid(Wave.Asteroid);
            
            yield return new WaitForSeconds(1f/ Wave.SpawnRate);
        }

        State = SpawnState.IDLE;


        yield break;
    }

    void SpawnAsteroid(GameObject Asteroid)
    {
        Debug.Log("Spawning Asteroid");
        Instantiate(Asteroid, transform.position, transform.rotation);
        
    }
    /* Written by LL */
}
