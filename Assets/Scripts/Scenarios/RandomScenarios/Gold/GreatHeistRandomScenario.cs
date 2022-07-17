using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatHeistRandomScenario : BaseScenario
{
    public override string title { get { return "The Great Heist"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 10; } }
    public override int minSuccess { get { return 18;} }
    public override int maxSuccess { get { return 21; } }
    public override int highRoll { get { return 25;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Ah, the grand galatic museum. It is home to many famous and expensive artworks.\n" +
            "You could attempt a hiest..";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            moneyToAdd = -50;

            postRollTextList.Add("You were caught sneaking around.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 50;

            postRollTextList.Add("The heist went pretty well. You got your hands on some of the artifacts.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 100;

            postRollTextList.Add("The heist was a great success. You sold all of the museum's artifact.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 70;

            postRollTextList.Add("The heist was a success, but some artifacts got damaged in the process.");
        }
        else // Super High outcome
        {
            postRollTextList.Add("You blew up the museum, leaving nothing behind.");
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
