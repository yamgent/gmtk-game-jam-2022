using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobCleaningRobotRandomScenario : BaseScenario
{
    private int moneyToAdd = 0;
    
    public override string GetTitle()
    {
        return "Rob Cleaning Robot";
    }

    public override List<string> GetPreRollTextList()
    {
        return new List<string> {
            "You encountered a cleaning robot.",
            "No one's looking... Rob him!"
        };
    }

    public override void PerformRollResult(int rolledNumber)
    {
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
        //player money += moneyToAdd;
    }

    public override List<string> GetPostRollTextList(int rolledNumber)
    {
        return new List<string> {
            "Successfully stole " + moneyToAdd + " gold!",
            "Nice loot!"
        };
    }
}
