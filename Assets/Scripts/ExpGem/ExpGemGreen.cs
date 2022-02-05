using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGemGreen : ExpGem
{
    void Start()
    {
        base.Start();
        expAmount = 10;
        gainRadius = 5;
    }
}
