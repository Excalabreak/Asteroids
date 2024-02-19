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
    private void Start()
    {
        _currentAsteroids = new List<GameObject>();
    }

    /// <summary>
    /// every frame:
    /// check if level is complete
    /// check if need to spawn a UFO
    /// </summary>
    private void Update()
    {
        if (GameManager.Instance.playing && _currentAsteroids.Count <= 0 && _currentUFO == null)
        {
            GameManager.Instance.OnLevelComplete();
            startSpawningUFO = false;
            spawningUFO = false;
        }

        if (startSpawningUFO && !spawningUFO && _currentAsteroids.Count > 0 && _currentUFO == null)
        {
            SpawnUFO();
        }
    }

    /// <summary>
    /// spawns asteroids and starts UFO cycle
    /// </summary>
    public void SpawnEnemies()
    {
        int asteroidAmount = 3 + PlayerData.Instance.currentLevel - 1;

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

    /// <summary>
    /// removes asteriod to list
    /// </summary>
    /// <param name="asteroid">asteroid being removed</param>
    public void RemoveAsteroid(GameObject asteroid)
    {
        _currentAsteroids.Remove(asteroid);
    }

    /// <summary>
    /// adds asteroid to list
    /// </summary>
    /// <param name="asteroid">asteroid being added</param>
    public void AddAsteroid(GameObject asteroid)
    {
        _currentAsteroids.Add(asteroid);
    }

    /// <summary>
    /// removes all the asteroid in list and ufos
    /// </summary>
    public void RemoveAllEnemies()
    {
        if (_currentAsteroids.Count > 0)
        {
            for (int index = _currentAsteroids.Count - 1; index >= 0; index--)
            {
                Destroy(_currentAsteroids[index]);
                _currentAsteroids.RemoveAt(index);
            }
        }
        startSpawningUFO = false;
        spawningUFO = false;
        Destroy(_currentUFO);
    }

    /// <summary>
    /// calls to spawn UFO after random delay
    /// </summary>
    private void SpawnUFO()
    {
        float spawnDelay = Random.Range(0f, _maxUFOSpawnDelay);
        StartCoroutine(SpawnUFO(spawnDelay));
    }

    /// <summary>
    /// Instantiates UFO Prefab after a delay
    /// </summary>
    /// <param name="seconds">how long to wait to spawn next UFO</param>
    /// <returns></returns>
    private IEnumerator SpawnUFO(float seconds)
    {
        spawningUFO = true;
        yield return new WaitForSeconds(seconds);

        float randomNum = Random.Range(0f, 1f);
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

        if (randomNum < .25f)
        {
            _currentUFO = Instantiate(_smallUFOPrefab, new Vector3(0f, topRight.y + 5, 0f), Quaternion.identity);
        }
        else
        {
            _currentUFO = Instantiate(_bigUFOPrefab, new Vector3(0f, topRight.y + 5, 0f), Quaternion.identity);
        }

        BaseUFOScript currentUFOScript = _currentUFO.GetComponent<BaseUFOScript>(); 
        if (currentUFOScript.goingRight)
        {
            _currentUFO.transform.position = new Vector3(bottomLeft.x - 5, Random.Range(bottomLeft.y, topRight.y), 0f);
        }
        else
        {
            _currentUFO.transform.position = new Vector3(topRight.x + 5, Random.Range(bottomLeft.y, topRight.y), 0f);
        }

        currentUFOScript.Ready();
        spawningUFO = false;
    }
}
