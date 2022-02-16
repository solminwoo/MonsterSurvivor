using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.IO;

[System.Serializable]
public class Stat
{
    public int level;
    public float hp;
    public float speed;
    public float spawnCoolTime;
    public int numMonstersToSpawn;
    public string expGemType;

    public override string ToString()
    {
        return "level: " + level.ToString() 
               + " hp: " + hp.ToString()
               + " speed: " + speed.ToString()
               + " spawnCoolTime: " + spawnCoolTime.ToString()
               + " numMonstersToSpawn: " + numMonstersToSpawn.ToString()
               + " expGemType: " + expGemType;
    }
}

[System.Serializable]
public class Stats
{
    public Stat[] stats;

    public override string ToString()
    {
        string str = "";
        foreach (Stat stat in stats)
        {
            str += stat.ToString() + "\n";
        }

        return str;
    }
}

public class MonsterStats
{
    private static MonsterStats instance;
    private Stat[] m_stats;

    public MonsterStats()
    {
        string path = Application.dataPath + "/Scripts/Monsters/monster_stats.json";
        string jsonFile = File.ReadAllText(path);

        m_stats = JsonUtility.FromJson<Stats>(jsonFile).stats;
     }

    public static MonsterStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MonsterStats();
            }
            return instance;
        }
    }

    public Stat getStatByLevel(int level)
    {
        return m_stats[level-1];
    }
}
