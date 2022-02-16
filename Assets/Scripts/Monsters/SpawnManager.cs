using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.IO;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    public int m_monsterSpawnDistance = 10;

    private Player player;
    private MonsterStats m_monsterStats;
    
    private void Start()
    {
        m_monsterStats = MonsterStats.Instance;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        var monsterObjects = Resources.LoadAll("Monsters").Cast<GameObject>();
        foreach(GameObject monsterObject in monsterObjects)
        {
            Monster monster = (Monster)monsterObject.GetComponent(typeof(Monster));

            int level = monster.m_level;

            StartCoroutine(spawnMonsters(monsterObject, level));
        }
    }

    private Vector3 getRandomPosition()
    {
        int x = Random.Range(-m_monsterSpawnDistance, m_monsterSpawnDistance + 1);
        int randVal = Random.Range(0, 2) == 1 ? 1 : -1;
        float z = Mathf.Sqrt(m_monsterSpawnDistance * m_monsterSpawnDistance - x * x) * randVal;

        Vector3 playerPosition = player.transform.position;
        Vector3 spawnPoint = new Vector3(x, 0, z);
        return spawnPoint + playerPosition;
    }

    public IEnumerator spawnMonsters(GameObject monsterType, int level)
    {
        Stat stat = m_monsterStats.getStatByLevel(level);
        while (true)
        {
            yield return new WaitForSeconds(stat.spawnCoolTime);
            for (int i = 0; i < stat.numMonstersToSpawn; i++)
            {
                Instantiate(monsterType, getRandomPosition(), transform.rotation);
            }
        }
    }
}
