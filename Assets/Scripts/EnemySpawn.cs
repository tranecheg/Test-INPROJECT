using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnTime = 2f;
    public Transform player;
    void Start()
    {
        StartCoroutine(Spawn());  
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        while (true && player!=null)
        {
            Vector2 spawnPos = player.position;
            spawnPos += Random.insideUnitCircle.normalized * 8f;

            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
        
    }
}
