using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobSpacePoliceRandomScenario : BaseScenario
{
    public override string title { get { return "Rob Space Police"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 2; } }
    public override int minSuccess { get { return 9;} }
    public override int maxSuccess { get { return 11; } }
    public override int highRoll { get { return 13;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "The space police are pretty easy for experienced pirates to rob.\n" +
            "Though I should still be careful.. Getting arrested would mean the end of my career.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            healthToAdd = -999;

            postRollTextList.Add("You stole some gold from the police, but they managed to corner you. You were arrested.");
            postRollTextList.Add("Game over.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 8;
            healthToAdd = -2;

            postRollTextList.Add("You stole some gold from the police. They managed to get some shots on your ship, but you eventually escaped.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = rolledNumber;

            postRollTextList.Add("You stole some gold from the police. They tried to give chase, but could not keep up with you.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = rolledNumber * 2;

            postRollTextList.Add("You hit the space police hard and fast, stealing their gold. They could not retaliate at all.");
        }
        else // Super High outcome
        {
            moneyToAdd = rolledNumber * 2;

            postRollTextList.Add("You hit the space police hard and fast, stealing their gold. They could not retaliate at all.");
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
