using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject m_expGem;

    public float m_hp;
    public float m_speed;
    public int m_level;

    public Transform m_target_transform;

    public void Start()
    {
        m_target_transform = GameObject.FindGameObjectWithTag("Player").transform;
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
        // Debug.Log("demage: " + demage.ToString() + " hp: " + m_hp.ToString());
        
        if (m_hp <= 0)
        {
            // Debug.Log("Death");
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
