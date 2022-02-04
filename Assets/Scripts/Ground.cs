using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject enemyMonster1;

    public void spawnEnemy()
    {
        Instantiate(enemyMonster1, gameObject.transform);
    }
}
