using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSingleDamage : SingleDamage
{
    public float targetSearchRadius;
    public int projectileAmount = 2;
    public override void instantiateSkill(Transform executeFrom)
    {
        FindClosestEnemy(executeFrom);
        Skill instantiatedSkill = Instantiate(skillPrefab, executeFrom.position, Quaternion.identity);
    }

    void findEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Enemy") ? GameObject.FindGameObjectWithTag("Enemy").GetComponent<Monster>() : null;
    }

    public void FindClosestEnemy(Transform executeFrom)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length < 1) return;
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = executeFrom.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        target = closest.GetComponent<Monster>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, targetSearchRadius);

    }
}
