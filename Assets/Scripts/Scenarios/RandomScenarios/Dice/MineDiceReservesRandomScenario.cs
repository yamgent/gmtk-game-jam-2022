using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDiceReservesRandomScenario : BaseScenario
{
    public override string title { get { return "Mine Dice Reserves"; } }
    public override string rewardsString { get { return "Dice"; } }
    public override int lowRoll { get { return 3; } }
    public override int minSuccess { get { return 10;} }
    public override int maxSuccess { get { return 12; } }
    public override int highRoll { get { return 15;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You enter a dice reserves, and see some mining tools left on the ground.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            postRollTextList.Add("No dice found, reserves is empty!");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            diceToAdd = 3;

            postRollTextList.Add("You mined some dice.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            diceToAdd = 5;

            postRollTextList.Add("You got your hands dirty with the mining tools.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            diceToAdd = 3;

            postRollTextList.Add("You mined some dice.");
        }
        else // Super High outcome
        {
            diceToAdd = 2;

            postRollTextList.Add("You found 10 dice, but 8 were destroyed while mining.");
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
