using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrrPiratesRandomScenario : BaseScenario
{
    public override string title { get { return "R & R"; } }
    public override string rewardsString { get { return "Health"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 3;} }
    public override int maxSuccess { get { return 5; } }
    public override int highRoll { get { return 99;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "It's those damn Arrr pirates! Kill them all!";
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
            healthToAdd = -5;

            postRollTextList.Add("You managed to kill them all, but took some damage in the process.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 10;

            postRollTextList.Add("You managed to kill them all, and looted their ship.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = rolledNumber * 5;
            healthToAdd = -rolledNumber;

            postRollTextList.Add("You followed them to their base and ambused them. You took some damage in the process, but looted their base.");
        }
        else // Super High outcome
        {
            moneyToAdd = rolledNumber * 5;
            healthToAdd = -rolledNumber;

            postRollTextList.Add("You followed them to their base and ambused them. You took some damage in the process, but looted their base.");
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
