using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exp : MonoBehaviour
{
    public Image expBar;
    public Player player;
    public TextMeshProUGUI textObject;
    public SkillManager skillManager;
    public Skill tornado;
    public GameObject levelUpUI;

    public int level;
    public float currentExp;
    public float maxExp = 10;

    private void Update()
    {
        if (currentExp - maxExp >= 0)
        {
            levelUp();
        }
    }

    public void gainExp(float x)
    {
        currentExp += x;
        adjustExpBar();
    }

    public void levelUp()
    {
        Pause.instance.pauseGame();
        levelUpUI.SetActive(true);
        level++;
        currentExp -= maxExp;
        maxExp *= 1.5f;
        textObject.text = "Level: " + level;
        adjustExpBar();
        skillManager.learnSkill(tornado);
        
    }

    void adjustExpBar()
    {
        expBar.fillAmount = currentExp / maxExp;
    }
}
