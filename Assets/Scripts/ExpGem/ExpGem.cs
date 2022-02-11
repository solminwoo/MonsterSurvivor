using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGem : MonoBehaviour
{
    public Exp exp;
    public Player player;

    public float expAmount;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        exp = GameObject.FindObjectOfType<Exp>();
    }

    private void Update()
    {
        if(getDistanceToPlayer() < player.gainRadius)
        {
            attractedToPlayer();
        }

        if(getDistanceToPlayer() < .1f)
        {
            exp.gainExp(expAmount);
            Destroy(gameObject);
        }
    }

    private float getDistanceToPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance;
    }

    public void attractedToPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * 10f, Space.World);
    }
}
