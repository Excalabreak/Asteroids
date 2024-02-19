using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [manages all enemies in scene]
 */

public class EnemyManager : Singleton<EnemyManager>
{
    //enemy prefabs
    [SerializeField] private GameObject _bigAsteroidPrefab;
    [SerializeField] private GameObject _bigUFOPrefab;
    [SerializeField] private GameObject _smallUFOPrefab;

    //all enemies
    private List<GameObject> _currentAsteroids;
    private GameObject _currentUFO;

    //ufo random spawn variables
    [SerializeField] private float _maxUFOSpawnDelay = 10f;
    private bool startSpawningUFO = false;
    private bool spawningUFO = false;

    /// <summary>
    /// sets up list
    /// </summary>
    public override void Awake()
    {
        base.Awake();

        _currentAsteroids = new List<GameObject>();
    }

    /// <summary>
    /// spawns asteroids and starts UFO cycle
    /// </summary>
    public void SpawnEnemies()
    {
        int asteroidAmount = 1 + PlayerData.Instance.currentLevel - 1;

        for (int index = 0; index < asteroidAmount; index++)
        {
            Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
            Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

            Vector3 spawn = new Vector3(Random.Range(bottomLeft.x, topRight.x), Random.Range(bottomLeft.y, topRight.y), 0f);
            GameObject asteroid = Instantiate(_bigAsteroidPrefab, spawn, Quaternion.identity);

            _currentAsteroids.Add(asteroid);
        }

        StartCoroutine(SpawnUFO(_maxUFOSpawnDelay));
        startSpawningUFO = true;
    }
    /*
     * note:
     * when spawning ufo:
     * delay from start of the level
     * spawn off of one side of the screen
     * when destroid, random delay till next saucer (next saucer is random)
     * repeat
     * spawn from one side of the screen
     */

    /// <summary>
    /// Instantiates UFO Prefab after a delay
    /// </summary>
    /// <param name="seconds">how long to wait to spawn next UFO</param>
    /// <returns></returns>
    private IEnumerator SpawnUFO(float seconds)
    {
        spawningUFO = true;
        yield return new WaitForSeconds(seconds);

        float randomNum = Random.Range(0, 1);
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

        if (randomNum < .25f)
        {
            _currentUFO = Instantiate(_smallUFOPrefab, new Vector3(0f, topRight.y + 5, 0f), Quaternion.identity);
        }
        else
        {
            _currentUFO = Instantiate(_smallUFOPrefab, new Vector3(0f, topRight.y + 5, 0f), Quaternion.identity);
        }

        BaseUFOScript currentUFOScript = _currentUFO.GetComponent<BaseUFOScript>(); 
        if (currentUFOScript.goingRight)
        {
            _currentUFO.transform.position = new Vector3(bottomLeft.x - 5, Random.Range(bottomLeft.y, topRight.y), 0f);
        }
        else
        {
            _currentUFO.transform.position = new Vector3(topRight.x - 5, Random.Range(bottomLeft.y, topRight.y), 0f);
        }
    }
}
