using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] m_monsterTypes;
    private List<KeyValuePair<GameObject, int> > m_monsters = new List<KeyValuePair<GameObject, int> >();
    public int m_monsterSpawnDistance = 10;

    Dictionary<int, Dictionary<string, float>> m_monsterInfo = new Dictionary<int, Dictionary<string, float>>()
    {
        {1, new Dictionary<string, float>()
            {
                {"lastSpawnTime", 4f},
                {"spawnCooltime", 5f},
                {"numberOfMonsterToSpawn", 1f}
            }
        },
        {2, new Dictionary<string, float>()
            {
                {"lastSpawnTime", 0f},
                {"spawnCooltime", 10f},
                {"numberOfMonsterToSpawn", 1f}
            }
        },
        {3, new Dictionary<string, float>()
            {
                {"lastSpawnTime", 0f},
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
            
            m_monsters.Add(new KeyValuePair<GameObject, int>(monsterType, monster.m_level));
        }
    }

    private void Update()
    {
        // Debug.Log(m_monsters.Capacity);
        foreach(KeyValuePair<GameObject, int> kvp in m_monsters)
        {
            GameObject go = kvp.Key;
            int level = kvp.Value;
            // Debug.Log(GameObject.ToString());
            // Debug.Log(level);

            m_monsterInfo[level]["lastSpawnTime"] += Time.deltaTime;
            // Debug.Log("spawnCooltime: " + m_monsterInfo[level]["spawnCooltime"].ToString());
            // Debug.Log("lastSpawnTime: " + m_monsterInfo[level]["lastSponTime"].ToString());

            if (m_monsterInfo[level]["lastSpawnTime"] > m_monsterInfo[level]["spawnCooltime"])
            {
                // Debug.Log(m_monsterInfo[level]["lastSponTime"]);
                m_monsterInfo[level]["lastSpawnTime"] -= m_monsterInfo[level]["spawnCooltime"];
                spawnMonster(go, (int)m_monsterInfo[level]["numberOfMonsterToSpawn"]);
            }
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

    void spawnMonster(GameObject monsterType, int numberOfMonsterToSpawn)
    {
        for (int i = 0; i < numberOfMonsterToSpawn; i++)
        {
            Instantiate(monsterType, getRandomPosition(), defaultQaut);
        }
    }
}
