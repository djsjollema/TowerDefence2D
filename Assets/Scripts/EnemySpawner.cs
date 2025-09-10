using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        
    }


    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Instantiate(EnemyPrefab);
        }
    }
}
