using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRandomScenario : BaseScenario
{
    public override string title { get { return "Fall into a ditch"; } }
    public override string rewardsString { get { return "Dice"; } }
    public override int lowRoll { get { return 3; } }
    public override int minSuccess { get { return 7;} }
    public override int maxSuccess { get { return 12; } }
    public override int highRoll { get { return 14;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You fall into a muddy ditch and get dirty.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            healthToAdd = -4;

            postRollTextList.Add("You feel disgusted and desperately want a bath.");
            postRollTextList.Add("As you attempt to climb out, you step on a dice, breaking it and falling back into the ditch.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 5;
            healthToAdd = -2;

            postRollTextList.Add("You find some gold in the ditch. Every cloud has a silver lining.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 5;
            healthToAdd = -2;
            diceToAdd = 2;

            postRollTextList.Add("You find gold and dice in the ditch. Amazing!");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            healthToAdd = -2;
            diceToAdd = 2;

            postRollTextList.Add("You find some dice in the ditch. You wonder if it was worth getting muddy for.");
        }
        else // Super High outcome
        {
            healthToAdd = -2;

            postRollTextList.Add("You feel disgusted and desperately want a bath.");
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
