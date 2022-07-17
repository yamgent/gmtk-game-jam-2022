using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaboteurRandomScenario : BaseScenario
{
    public override string title { get { return "Saboteur"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 10; } }
    public override int minSuccess { get { return 18;} }
    public override int maxSuccess { get { return 21; } }
    public override int highRoll { get { return 25;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Your rival planted a bomb in your ship.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            moneyToAdd = -100;
            healthToAdd = -10;

            postRollTextList.Add("You did not realize there was a bomb on your ship. It blew up with you inside.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = -70;

            postRollTextList.Add("The bomb exploded as you threw it out of the window. Part of the ship was damaged.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            postRollTextList.Add("You disarmed the bomb.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 20;

            postRollTextList.Add("You disarmed the bomb and took it apart to sell.");
        }
        else // Super High outcome
        {
            healthToAdd = -10;
            
            postRollTextList.Add("You disarmed the bomb and tried to take it apart to sell, but it blew up.");
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
