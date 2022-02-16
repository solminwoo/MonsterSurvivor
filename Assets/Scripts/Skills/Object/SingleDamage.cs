using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDamage : Skill
{
    public override void damage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, skillRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" || collider.tag == "Defense")
            {
                collider.gameObject.GetComponent<Monster>().takeDemage(skillDamage);
                Destroy(gameObject);
                break;
            }
        }
    }
}
