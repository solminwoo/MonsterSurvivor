using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cam;
    public Skill autoAttackPrefab;


    public CharacterController controller;
    public float speed = 6f;

    public float turnSmoothTime = .1f;
    public float turnSmoothVelocity;

    public float autoAttackCoolDown = 2.5f;
    public float currentAutoAttackCoolDown;

    private void Start()
    {
        currentAutoAttackCoolDown = autoAttackCoolDown;
    }
    void Update()
    {
        currentAutoAttackCoolDown -= Time.deltaTime;

        //Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }


        // Skill
        if (currentAutoAttackCoolDown < 0)
        {
            autoAttack();
        }

        
    }

    void autoAttack()
    {
        Instantiate(autoAttackPrefab,gameObject.transform);
        currentAutoAttackCoolDown = autoAttackCoolDown;
    }
}
