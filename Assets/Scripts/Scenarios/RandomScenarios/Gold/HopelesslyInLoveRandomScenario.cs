using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopelesslyInLoveRandomScenario : BaseScenario
{
    public override string title { get { return "Hopelessly In Love"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 6; } }
    public override int minSuccess { get { return 15;} }
    public override int maxSuccess { get { return 21; } }
    public override int highRoll { get { return 25;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You met the love of your life.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            moneyToAdd = -50;
            healthToAdd = -5;

            postRollTextList.Add("She left. You cried.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = -30;

            postRollTextList.Add("You bought a diamond ring to propose.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = -50;

            postRollTextList.Add("You held a wedding.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = -70;

            postRollTextList.Add("You bought a mansion.");
        }
        else // Super High outcome
        {
            moneyToAdd = -100;

            postRollTextList.Add("You handed over your credit card.");
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
