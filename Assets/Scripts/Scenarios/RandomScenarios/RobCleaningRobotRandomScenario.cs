using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobCleaningRobotRandomScenario : BaseScenario
{
    public override string title { get { return "Rob Cleaning Robot"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 2;} }
    public override int maxSuccess { get { return 5; } }
    public override int highRoll { get { return 6;} }

    private int moneyToAdd = 0;

    public override string GetDescription()
    {
        return "You encountered a cleaning robot.\n" +
            "No one's looking... Rob him!";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        if (rolledNumber <= 1)
        {
            moneyToAdd = 5;
        }
        else if (rolledNumber <= 5)
        {
            moneyToAdd = 10;
        }
        else
        {
            moneyToAdd = 5;
        }
        return new Vector3Int(moneyToAdd, 0, 0);
    }

    public override List<string> GetPostRollTextList()
    {
        return new List<string> {
            "Successfully stole " + moneyToAdd + " gold!",
            "Nice loot!"
        };
    }
}
