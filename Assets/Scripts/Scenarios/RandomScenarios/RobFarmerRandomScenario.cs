using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobFarmerRandomScenario : BaseScenario
{
    public override string title { get { return "Rob Farmer"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 2; } }
    public override int minSuccess { get { return 3;} }
    public override int maxSuccess { get { return 6; } }
    public override int highRoll { get { return 7;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Farmers are easy targets for pirates.\n" +
            "Time to earn some easy money.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            moneyToAdd = 5;
            healthToAdd = -1;

            postRollTextList.Add("Farmer attacked you with his rake. You beat him up and took his wallet.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 5;

            postRollTextList.Add("Farmer tried to attack you, but you dodged, and stole his wallet.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 10;

            postRollTextList.Add("Farmer begged you not to hurt him and gave all his gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 5;

            postRollTextList.Add("Farmer threw the gold at you in terror and fled.");
            postRollTextList.Add("Unfortunately, some of the gold fell into the drain and got washed away..");
        }
        else // Super High outcome
        {
            moneyToAdd = 5;

            postRollTextList.Add("Farmer threw the gold at you in terror and fled.");
            postRollTextList.Add("Unfortunately, some of the gold fell into the drain and got washed away..");
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

        return new Vector3Int(moneyToAdd, healthToAdd, 0);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
