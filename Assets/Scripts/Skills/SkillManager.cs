using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private IEnumerator coroutine;
    public Transform firePoint;

    [Header("Learned Skills")]
    public Skill[] skills;


    [Header("Skill1")]
    public Skill skillPrefab1;

    public void Start()
    {
        skills = new Skill[5];
        skills[0] = skillPrefab1;
        StartCoroutine(executeTheSkillFromHead(skillPrefab1));
    }

    public void learnSkill(Skill skillToLearn)
    {
        skills[1] = skillToLearn;
        StartCoroutine(executeTheSkillFromHead(skillToLearn));
    }

    public IEnumerator executeTheSkillFromHead(Skill skillToExecute)
    {
        while (true)
        {
            yield return new WaitForSeconds(skillToExecute.autoAttackCoolDown);
            skillToExecute.instantiateSkill(firePoint);
        }
    }

    public IEnumerator executeTheSkillFromGround(Skill skillToExecute)
    {
        while (true)
        {
            yield return new WaitForSeconds(skillToExecute.autoAttackCoolDown);
            skillToExecute.instantiateSkill(transform);
        }
    }
}
