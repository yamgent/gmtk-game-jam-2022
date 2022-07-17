using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundCasinoRandomScenario : BaseScenario
{
    public override string title { get { return "Underground Casino"; } }
    public override string rewardsString { get { return "Dice"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 7;} }
    public override int maxSuccess { get { return 18; } }
    public override int highRoll { get { return 24;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "A hidden casino for VIPs only. Only accepts dice as bets.";
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
            postRollTextList.Add("The banker rolled a 7. Bad luck. Try again next time.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            diceToAdd = 3;

            postRollTextList.Add("The banker rolled a 6. You win some dice.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            diceToAdd = 8;

            postRollTextList.Add("The banker rolled an 18. You win!");
        }
        else // Super High outcome
        {
            diceToAdd = 20;

            postRollTextList.Add("You rolled the instant jackpot number!");
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
