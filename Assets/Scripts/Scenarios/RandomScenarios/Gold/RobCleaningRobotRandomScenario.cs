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
            "No one's looking.. Rob him!";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            moneyToAdd = 5;

            postRollTextList.Add("Successfully robbed the robot, taking some of its gold.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 5;

            postRollTextList.Add("Successfully robbed the robot, taking some of its gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 10;

            postRollTextList.Add("Successfully robbed the robot, taking all of its gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 5;

            postRollTextList.Add("Damaged the robot, causing it to drop all of its gold and sound an alarm.");
            postRollTextList.Add("Quickly grabbed whatever gold you could and ran away.");
        }
        else // Super High outcome
        {
            moneyToAdd = 5;

            postRollTextList.Add("Damaged the robot, causing it to drop all of its gold and sound an alarm.");
            postRollTextList.Add("Quickly grabbed whatever gold you could and ran away.");
        }

        if (moneyToAdd != 0 || healthToAdd != 0 || diceToAdd != 0) {
            string postRollRewardsText = "";
            if (moneyToAdd < 0) {
                postRollRewardsText += "Lose " + (-moneyToAdd) + " gold. ";
            } else if (moneyToAdd > 0) {
                postRollRewardsText += "Gain " + moneyToAdd + " gold. ";
            }
            if (healthToAdd < 0) {
                postRollRewardsText += "Lose " + (-healthToAdd) + " health. ";
            } else if (healthToAdd > 0) {
                postRollRewardsText += "Gain " + healthToAdd + " health. ";
            }
            if (diceToAdd < 0) {
                postRollRewardsText += "Lose " + (-diceToAdd) + " dice. ";
            } else if (diceToAdd > 0) {
                postRollRewardsText += "Gain " + diceToAdd + " dice. ";
            }
            postRollTextList.Add(postRollRewardsText);
        }

        return new Vector3Int(moneyToAdd, 0, 0);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
