using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject monsterToSpawn;
    public int numberOfMonsterToSpawn = 20;
    public int monsterSpawnDistance = 20;

    public Quaternion defaultQaut = new Quaternion(0,0,0,0);


    //public GameObject[] grounds;
    //public int currentGroundIndex;
    //public Ground[] spawningGrounds;

    //public Ground spawningGroundN;
    //public Ground spawningGroundS;
    //public Ground spawningGroundE;
    //public Ground spawningGroundW;

    public float spawnCountDown = 4f;
    public float currentCountDown;

    public Player player;

    //private void Awake()
    //{
    //    grounds = GameObject.FindGameObjectsWithTag("Ground");
    //    currentGroundIndex = 4;
    //    spawningGroundN = grounds[currentGroundIndex - 3].GetComponent<Ground>();
    //    spawningGroundS = grounds[currentGroundIndex + 3].GetComponent<Ground>();
    //    spawningGroundE = grounds[currentGroundIndex + 1].GetComponent<Ground>();
    //    spawningGroundW = grounds[currentGroundIndex - 1].GetComponent<Ground>();
    //    spawningGrounds = new Ground[] { spawningGroundN, spawningGroundS, spawningGroundE, spawningGroundW };
    //}

    //private void Start()
    //{
    //}

    //private void Update()
    //{
    //    currentCountDown += Time.deltaTime;
    //    if (currentCountDown > spawnCountDown)
    //    {
    //        foreach(Ground spwaningGround in spawningGrounds)
    //        {
    //            spwaningGround.spawnEnemy();
    //        }
    //        currentCountDown = 0;
    //    }
    //}

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        currentCountDown += Time.deltaTime;
        if (currentCountDown > spawnCountDown)
        {
            spawnMonsterAtRandPosition();
            currentCountDown = 0;
        }
    }

    void spawnMonsterAtRandPosition()
    {
        for (int i = 0; i < numberOfMonsterToSpawn; i++)
        {
            int x = Random.Range(-monsterSpawnDistance, monsterSpawnDistance + 1);
            int randVal = Random.Range(0, 2) == 1 ? 1 : -1;
            float z = Mathf.Sqrt(monsterSpawnDistance * monsterSpawnDistance - x * x) * randVal;

            Vector3 spawnPoint = new Vector3(x, 0, z);
            Instantiate(monsterToSpawn, spawnPoint, defaultQaut);
        }
    }
}
