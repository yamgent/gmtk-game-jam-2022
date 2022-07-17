using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCloningMachineRandomScenario : BaseScenario
{
    public override string title { get { return "Dice Cloning Machine"; } }
    public override string rewardsString { get { return "Dice"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 7;} }
    public override int maxSuccess { get { return 21; } }
    public override int highRoll { get { return 25;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "An old machine with the text \"Clone your dice here!\" written on its screen. Insert dice?";
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
            postRollTextList.Add("The machine broke down immediately after you put in your dice. Is this a scam?!");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            diceToAdd = 6;

            postRollTextList.Add("The machine rocked back and forth.. and you gave it a hard kick. A bunch of dice rolled out. Oh, it actually works!");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            diceToAdd = 4;

            postRollTextList.Add("The machine rocked back and forth.. and something seems stuck. A few dice rolled out.");
            postRollTextList.Add("Oh well, at least I got my dice back.");
        }
        else // Super High outcome
        {
            diceToAdd = 4;

            postRollTextList.Add("The machine rocked back and forth.. and something seems stuck. A few dice rolled out.");
            postRollTextList.Add("Oh well, at least I got my dice back.");
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
