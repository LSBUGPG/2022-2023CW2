using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 20) 
        {
            xPos = Random.Range(-12, 13);
            zPos= Random.Range(35, 55);
            Instantiate(theEnemy,new Vector3(xPos, 3, zPos), Quaternion.identity);  
            yield return new WaitForSeconds(0.5f);
            enemyCount += 1;
        }
    }
}
