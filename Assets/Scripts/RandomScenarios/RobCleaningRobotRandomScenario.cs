using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobCleaningRobotRandomScenario : RandomScenario
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string GetTitle()
    {
        return "Rob Cleaning Robot";
    } 

    public override void PerformResult(int rolledNumber)
    {
        int moneyToAdd = 0;
        if (rolledNumber <= 1)
        {
            moneyToAdd = 5;
        }
        else if (rolledNumber <= 5)
        {
            moneyToAdd = 10;
        }
        else if (rolledNumber <= 6)
        {
            moneyToAdd = 5;
        }
        resultText = "Successfully stole " + moneyToAdd + " gold";
        //player money += moneyToAdd;
    }
}
