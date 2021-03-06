using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDamage : Skill
{
    public override void damage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, skillRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" || collider.tag == "Defense")
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
