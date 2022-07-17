using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestRandomScenario : BaseScenario
{
    public override string title { get { return "Found a Treasure Chest"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 2; } }
    public override int minSuccess { get { return 3;} }
    public override int maxSuccess { get { return 6; } }
    public override int highRoll { get { return 7;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "A treasure chest! What could be inside?";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            healthToAdd = -5;

            postRollTextList.Add("The chest was rigged with explosives and blew up when you opened it.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            postRollTextList.Add("The treasure chest is empty. Someone must have looted it before you..");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = rolledNumber * 2;

            postRollTextList.Add("The treasure chest is full of gold!");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 20;

            postRollTextList.Add("The treasure chest is practically overflowing with gold!");
        }
        else // Super High outcome
        {
            moneyToAdd = 20;

            postRollTextList.Add("The treasure chest is practically overflowing with gold!");
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
