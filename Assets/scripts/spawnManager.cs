using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _enemyContainer;
    public bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (!stopSpawning)
        {
            Vector3 posToSpawn = new Vector3 (Random.Range(-12,12), 6, 0);
            GameObject newEnemy = Instantiate(_enemy,posToSpawn,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }

    }

    public void GameEnd()
    {
        stopSpawning = true;
    }
}
