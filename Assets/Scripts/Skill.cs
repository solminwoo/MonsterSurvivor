using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{


    [Header("Attributes")]
    public float skillRadius = 2f;
    public float speed = 30f;
    public float skillDamage;


    // Update is called once per frame
    void Update()
    {
        //hit infront of the target
        if (Physics.OverlapSphere(transform.position, skillRadius).Length>0)
        {
            HitTarget();
            return;
        }
    }

    void HitTarget()
    {
        //GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, 2f);

        if (skillRadius > 0f)
        {
            AreaOfEffect();
        }
    }

    void AreaOfEffect()
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

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        //Gizmos.color = new Color(1, 1, 0, 0.75F);
        //Gizmos.DrawSphere(transform.position, skillRadius);
    }
}
