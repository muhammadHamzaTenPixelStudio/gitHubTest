using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject[] _powerUpsObjs;

    [SerializeField] GameObject _enemyContainer;
    [SerializeField] GameObject _powerUpContainer;
    public bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        while (!stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-12, 12), 6, 0);
            GameObject newEnemy = Instantiate(_enemy, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }

    public void GameEnd()
    {
        stopSpawning = true;
    }

    IEnumerator SpawnPowerUps()
    {
        while (!stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-10, 10), 7, 0);
            int powerUpVal = Random.Range(0, 3);
            GameObject newTriple = Instantiate(_powerUpsObjs[powerUpVal], posToSpawn, Quaternion.identity);
            newTriple.transform.parent = _powerUpContainer.transform;
            yield return new WaitForSeconds(Random.Range(3f,8f));
        }
    }
    
}
