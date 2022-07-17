using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDiceMinesRandomScenario : BaseScenario
{
    public override string title { get { return "Mine Dice Reserves"; } }
    public override string rewardsString { get { return "Dice"; } }
    public override int lowRoll { get { return 12; } }
    public override int minSuccess { get { return 14;} }
    public override int maxSuccess { get { return 16; } }
    public override int highRoll { get { return 18;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You found a secret cave that could be full of dice. Time to get digging.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            postRollTextList.Add("The dice you found were too old to be used.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            diceToAdd = 3;

            postRollTextList.Add("After hours of back-breaking digging, you found a few dice.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            diceToAdd = 7;

            postRollTextList.Add("Your intuition was spot on, and you found a lot of dice!");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            diceToAdd = 3;

            postRollTextList.Add("The tunnel ahead collapsed infront of you. There is no way to dig for more dice.");
            postRollTextList.Add("Fortunately, you already found enough dice to make it a fruitful endeavour.");
        }
        else // Super High outcome
        {
            healthToAdd = -10;

            postRollTextList.Add("Your intuition was spot on, and you found a lot of dice!");
            postRollTextList.Add("But the tunnel collapsed above you.");
            postRollTextList.Add("You could not retrieve any dice, and got hurt in the process.");
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
