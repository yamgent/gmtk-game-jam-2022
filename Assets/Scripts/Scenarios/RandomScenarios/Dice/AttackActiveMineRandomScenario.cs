using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackActiveMineRandomScenario : BaseScenario
{
    public override string title { get { return "Attack Active Dice Mine"; } }
    public override string rewardsString { get { return "Dice"; } }
    public override int lowRoll { get { return 4; } }
    public override int minSuccess { get { return 7;} }
    public override int maxSuccess { get { return 11; } }
    public override int highRoll { get { return 14;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You found an active dice mine. You can threaten the mines to get the miners to mine for you.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            diceToAdd = 1;

            postRollTextList.Add("The miners refuse to mine for you. You secretly mine some dice.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            diceToAdd = 4;
            moneyToAdd = -10;

            postRollTextList.Add("The miners agree to help you mine dice in exchange for gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            diceToAdd = 4;

            postRollTextList.Add("The miners agree to help you mine dice.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            diceToAdd = 3;
            healthToAdd = -5;

            postRollTextList.Add("The miners refuse initially, but agree after a short battle.");
        }
        else // Super High outcome
        {
            healthToAdd = -10;

            postRollTextList.Add("The miners refuse and a battle ensues.. You killed all the miners, but lost a lot of health too.");
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
