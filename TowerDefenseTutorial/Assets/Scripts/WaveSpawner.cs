using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5.5f;
    public Text timerDisplay;

    private float countdown = 2.5f;
    private int waveIndex = 0;

    void Start()
    {
        //UpdateCountdown();
    }

    void Update()
    {        
        if (countdown < -0.5f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;           
        }
        UpdateCountdown();
        countdown -= Time.deltaTime;        
    }

    void UpdateCountdown()
    {
        timerDisplay.text = "Next Wave in " + Mathf.Round(countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
