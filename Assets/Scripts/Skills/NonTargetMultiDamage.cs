using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonTargetMutiDamage : MultiDamage
{
    public override void instantiateSkill(Transform executeFrom) {
        Instantiate(skillPrefab, executeFrom.position, executeFrom.rotation);
    }
}
