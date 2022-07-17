using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiracleDrugRandomScenario : BaseScenario
{
    public override string title { get { return "A Miracle Drug?"; } }
    public override string rewardsString { get { return "Health"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 5;} }
    public override int maxSuccess { get { return 13; } }
    public override int highRoll { get { return 99;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You visit a doctor to get your wounds treated.";
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
            healthToAdd = 1;

            postRollTextList.Add("The drug does not seem to have much effect.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            healthToAdd = 20;

            postRollTextList.Add("The drug makes you feel much stronger.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            healthToAdd = 50;

            postRollTextList.Add("Your backache is gone and you feel 10 years younger.");
        }
        else // Super High outcome
        {
            healthToAdd = 50;

            postRollTextList.Add("Your backache is gone and you feel 10 years younger.");
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
