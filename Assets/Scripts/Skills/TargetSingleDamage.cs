using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSingleDamage : SingleDamage
{
    public float targetSearchRadius;
    private float minDist = Mathf.Infinity;
    public override void instantiateSkill(Transform executeFrom)
    {
        findEnemy();
        Skill instantiatedSkill = Instantiate(skillPrefab, executeFrom.position, Quaternion.identity);
    }

    void findEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Enemy") ? GameObject.FindGameObjectWithTag("Enemy").GetComponent<Monster>() : null;
    }
    //Doesn't work that well 
    void findNearestEnemy()
    {
        if (Physics.OverlapSphere(transform.position, targetSearchRadius).Length > 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, targetSearchRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    float currentDist = Vector3.Distance(collider.transform.position, transform.position);
                    if (currentDist < minDist)
                    {
                        minDist = currentDist;
                        target = collider.GetComponent<Monster>();
                    }
                }
            }
        }
    }
}
