using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Skill skillPrefab;
    public float autoAttackCoolDown;
    public Monster target;

    [Header("Attributes")]
    public float skillRadius;
    public float speed;
    public float skillDamage;
    public bool singleTargeting;
    public bool trageting;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            moveTowardsEnemy();
        }
        else{
            //TODO when target is destoryed make object to move smooth with the current dir
            //transform.Translate(transform.position.normalized * speed, Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //hit infront of the target
        if (Physics.OverlapSphere(transform.position, skillRadius).Length > 0)
        {
            damage();
            return;
        }
    }

    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public virtual void damage() { }
    public virtual void instantiateSkill(Transform executeFrom) { }


    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        //Gizmos.color = new Color(1, 1, 0, 0.75F);
        //Gizmos.DrawSphere(transform.position, skillRadius);
    }

    void moveTowardsEnemy()
    {
        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * speed, Space.World);
        transform.LookAt(target.transform);
    }
}
