using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, IDLE, COUNTING };
    
    public Wave[] Waves;
    private int NextWave = 0;

    public float TimeBetweenWaves = 5f;
    public float WaveCountdown;

    private float SearchFrequency = 1f;

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

    IEnumerator SpawnWave(Wave _Wave)
    {
        Debug.Log("Spawning Wave" + _Wave.Count);
        State = SpawnState.SPAWNING;

        for (int i = 0; i < _Wave.Count; i++)
        {
            SpawnAsteroid(_Wave.Asteroid);
            yield return new WaitForSeconds(1f/ _Wave.SpawnRate);
        }

        State = SpawnState.IDLE;


        yield break;
    }

    void SpawnAsteroid(Transform Asteroid)
    {
        Debug.Log("Spawning Asteroid");
        Instantiate(Asteroid, transform.position, transform.rotation);
        
    }
}
