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

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You encountered a cleaning robot.\n" +
            "No one's looking... Rob him!";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int goldToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            goldToAdd = 5;

            postRollTextList.Add("Successfully robbed the robot, taking some of its gold.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            goldToAdd = 5;

            postRollTextList.Add("Successfully robbed the robot, taking some of its gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            goldToAdd = 10;

            postRollTextList.Add("Successfully robbed the robot, taking all of its gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            goldToAdd = 5;

            postRollTextList.Add("Damaged the robot, causing it to drop all of its gold and sound an alarm.");
            postRollTextList.Add("Quickly grabbed whatever gold you could and ran away.");
        }
        else // Super High outcome
        {
            goldToAdd = 5;

            postRollTextList.Add("Damaged the robot, causing it to drop all of its gold and sound an alarm.");
            postRollTextList.Add("Quickly grabbed whatever gold you could and ran away.");
        }

        postRollTextList.Add("Nice loot! Gained " + goldToAdd + " gold.");

        return new Vector3Int(goldToAdd, 0, 0);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
