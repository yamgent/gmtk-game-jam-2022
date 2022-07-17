using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositivityRandomScenario : BaseScenario
{
    public override string title { get { return "Space Positivity Day"; } }
    public override string rewardsString { get { return "Health"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 5;} }
    public override int maxSuccess { get { return 9; } }
    public override int highRoll { get { return 99;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Today is Space Positivity Day!\n" +
            "Time to take a break from all the robbing for your mental health.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            // Not possible.
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            healthToAdd = 5;

            postRollTextList.Add("You slept for 9 hours.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            healthToAdd = 10;

            postRollTextList.Add("You received a compliment.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = -20;
            healthToAdd = 10;

            postRollTextList.Add("You bought the pair of watch you have always wanted.");
        }
        else // Super High outcome
        {
            moneyToAdd = -20;
            healthToAdd = 10;

            postRollTextList.Add("You bought the pair of watch you have always wanted.");
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

        return new Vector3Int(moneyToAdd, healthToAdd, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
