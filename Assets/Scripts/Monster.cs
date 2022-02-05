using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp = 10;
    public float speed = 2f;
    public float elapsedTime;


    public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed , Space.World);
        transform.LookAt(target);
    }
}
