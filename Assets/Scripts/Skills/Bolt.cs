using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : TargetSingleDamage
{
    void Start()
    {
        skillRadius = .75f;
        speed = .1f;
        skillDamage = 5;
        singleTargeting = true;
        trageting = true;
        autoAttackCoolDown = 1f;
        targetSearchRadius = 20f;
    }
}
