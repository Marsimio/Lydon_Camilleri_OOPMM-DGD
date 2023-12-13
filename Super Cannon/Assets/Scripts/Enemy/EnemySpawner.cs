using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemySO> enemyList = new List<EnemySO>();
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }



    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int enemyChoice = Random.Range(0, enemyList.Count);
            Vector3 enemypos = new Vector3(Random.Range(GameData.XMin, GameData.XMax), GameData.YMax+1);
            GameObject enemyInstance = Instantiate(enemyList[enemyChoice].enemyprefab, enemypos, Quaternion.identity);
            enemyInstance.GetComponent<Enemy>().start_hitpoints = enemyList[enemyChoice].hitpoints;
            enemyInstance.GetComponent<Enemy>().start_strength = enemyList[enemyChoice].strength;
            enemyInstance.GetComponent<Enemy>().start_speed = enemyList[enemyChoice].speed;
            yield return new WaitForSeconds(1f);
        }
    }


}
