using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGem : MonoBehaviour
{
    public Exp exp;
    public Player player;

    public int expAmount;
    public float gainRadius;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        exp = GameObject.FindObjectOfType<Exp>();
    }

    private void Update()
    {
        if(getDistanceToPlayer() < gainRadius)
        {
            attractedToPlayer();
        }

        if(getDistanceToPlayer() < .1f)
        {
            Destroy(gameObject);
            exp.gainExp(expAmount);
        }
    }

    private float getDistanceToPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance;
    }
    //private void OnDestroy()
    //{
    //    exp.gainExp(expAmount);
    //}

    public void attractedToPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        //transform.position = Vector3.Lerp(transform.position, target.position, 1/movementSpeed);
        transform.Translate(dir.normalized * Time.deltaTime * 10f, Space.World);
    }
}
