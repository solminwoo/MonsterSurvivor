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
        level++;
        currentExp -= maxExp;
        maxExp *= 1.5f;
        textObject.text = "Level: " + level;
        adjustExpBar();
    }

    void adjustExpBar()
    {
        expBar.fillAmount = currentExp / maxExp;
    }
}
