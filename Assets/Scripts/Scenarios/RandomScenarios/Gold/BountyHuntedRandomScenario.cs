using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHuntedRandomScenario : BaseScenario
{
    public override string title { get { return "Bounty Hunted"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 6; } }
    public override int minSuccess { get { return 15;} }
    public override int maxSuccess { get { return 21; } }
    public override int highRoll { get { return 25;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Your infamy has spread far and wide.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            moneyToAdd = -20;
            healthToAdd = -5;

            postRollTextList.Add("The bounty hunter was merciless. At least gold is merciful..");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = -20;

            postRollTextList.Add("You got bested. But nothing a little bit of gold couldnt solve.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            postRollTextList.Add("You defeat the bounty hunter.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            postRollTextList.Add("You bested the bounty hunter. It should take a good six months before he could move again.");
        }
        else // Super High outcome
        {
            moneyToAdd = rolledNumber * 2;
            
            postRollTextList.Add("You overdid it.. It is always safer to hush the prying eyes.");
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
