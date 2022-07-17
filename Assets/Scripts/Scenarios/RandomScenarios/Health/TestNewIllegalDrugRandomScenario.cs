using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNewIllegalDrugRandomScenario : BaseScenario
{
    public override string title { get { return "Test new illegal drug"; } }
    public override string rewardsString { get { return "Health"; } }
    public override int lowRoll { get { return 4; } }
    public override int minSuccess { get { return 7;} }
    public override int maxSuccess { get { return 15; } }
    public override int highRoll { get { return 17;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You are given the opportunity to try out the newest drug.\n" +
            "The drug dealer promises it will grant you immense strength.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            healthToAdd = -3;

            postRollTextList.Add("Your body does not react well to the drug. Seems like you are allergic.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            healthToAdd = 1;

            postRollTextList.Add("The drug does not seem to have much effect.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            healthToAdd = 10;

            postRollTextList.Add("The drug makes you feel stronger.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            healthToAdd = -5;

            postRollTextList.Add("The drug makes you feel much stronger.");
            postRollTextList.Add("You attempt to show off by lifting your spaceship, injuring your back.");
        }
        else // Super High outcome
        {
            healthToAdd = 10;
            moneyToAdd = -10;

            postRollTextList.Add("The drug makes you feel stronger, but you got addicted to it.");
            postRollTextList.Add("Spend some money to purchase more.");
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
