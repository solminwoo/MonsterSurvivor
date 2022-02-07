using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Learned Skills")]
    public Skill[] skills;


    [Header("Skill1")]
    public Skill skillPrefab1;
    public float skillTimer1 =4f;

    //[Header("Skill2")]
    //public Skill skillPrefab2;
    //public float skillTimer2 = 4f;
    
    //[Header("Skill3")]
    //public Skill skillPrefab3;
    //public float skillTimer3 = 4f;

    void Start()
    {
        skillTimer1 = skillPrefab1.autoAttackCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        skillTimer1 -= Time.deltaTime;
        if ( skillTimer1<0)
        {
            skillPrefab1.instantiateSkill(transform);
            skillTimer1 = skillPrefab1.autoAttackCoolDown;
        }
    }

    public void learnSkill(Skill skillToLearn)
    {
        skills.SetValue(skillToLearn, skills.Length );
    }
}
