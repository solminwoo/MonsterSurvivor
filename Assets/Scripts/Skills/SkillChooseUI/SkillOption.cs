using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillOption : MonoBehaviour
{
    public Skill skillPrefab;
    public SkillManager skillManager;

    public void learnChosenSkill()
    {
        skillManager.learnSkill(skillPrefab);
        Pause.instance.unPauseGame();
    }

}
