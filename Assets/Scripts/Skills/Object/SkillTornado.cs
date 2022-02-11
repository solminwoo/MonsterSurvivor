using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTornado : NonTargetMutiDamage
{
    // Start is called before the first frame update
    void Start()
    {
        skillRadius = 2f;
        speed = .05f;
        skillDamage = 5;
        singleTargeting = false;
        trageting = false;
        autoAttackCoolDown = 4f;
    }


}
