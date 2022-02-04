using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleMonster : MonoBehaviour
{
    public int hp =100;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int dam)
    {
        hp -= dam;
    }
}
