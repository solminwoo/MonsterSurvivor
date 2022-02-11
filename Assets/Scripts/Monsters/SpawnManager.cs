using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] m_monsterTypes;
    public int m_monsterSpawnDistance = 10;

    Dictionary<int, Dictionary<string, float>> m_monsterInfo = new Dictionary<int, Dictionary<string, float>>()
    {
        {1, new Dictionary<string, float>()
            {
                {"spawnCooltime", 2f},
                {"numberOfMonsterToSpawn", 2f}
            }
        },
        {2, new Dictionary<string, float>()
            {
                {"spawnCooltime", 10f},
                {"numberOfMonsterToSpawn", 1f}
            }
        },
        {3, new Dictionary<string, float>()
            {
                {"spawnCooltime", 20f},
                {"numberOfMonsterToSpawn", 1f}
            }
        }

    };
    public Quaternion defaultQaut = new Quaternion(0,0,0,0);

    public Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        foreach(GameObject monsterType in m_monsterTypes)
        {
            Monster monster = (Monster)monsterType.GetComponent(typeof(Monster));

            int level = monster.m_level;

            StartCoroutine(spawnMonsters(monsterType, level));
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
        while (true)
        {
            yield return new WaitForSeconds(m_monsterInfo[level]["spawnCooltime"]);
            for (int i = 0; i < (int)m_monsterInfo[level]["numberOfMonsterToSpawn"]; i++)
            {
                Instantiate(monsterType, getRandomPosition(), defaultQaut);
            }
        }
    }
}
