using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameObject m_expGem;

    private float m_hp;
    private float m_speed;
    public int m_level;

    private Transform m_target_transform;

    public void Start()
    {
        m_target_transform = GameObject.FindGameObjectWithTag("Player").transform;
        Stat stat = MonsterStats.Instance.getStatByLevel(m_level);
        m_hp = stat.hp;
        m_speed = stat.speed;

        m_expGem = Resources.Load("ExpGems/" + stat.expGemType, typeof(GameObject)) as GameObject;

    }
    public void Update()
    {
        Vector3 dir = m_target_transform.position - transform.position;
        transform.Translate(dir * Time.deltaTime * m_speed, Space.World);
        transform.LookAt(m_target_transform);
    }

    public void takeDemage(float demage)
    {
        m_hp -= demage;
        
        if (m_hp <= 0)
        {
            dropExpGem();
            Destroy(gameObject);
        }
    }

    //TODO: Under Construction
    private void dropExpGem()
    {
        Instantiate(m_expGem, transform.position, new Quaternion(0,0,0,0));
        return;
    }
}
