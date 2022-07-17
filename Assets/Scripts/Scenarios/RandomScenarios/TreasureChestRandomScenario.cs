using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreaasureChestRandomScenario : BaseScenario
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
            postRollTextList.Add("Lose 5 health.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            postRollTextList.Add("The treasure chest is empty. Someone must have looted it before you..");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = rolledNumber * 2;

            postRollTextList.Add("The treasure chest is full of gold!");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 20;

            postRollTextList.Add("The treasure chest is practically overflowing with gold!");
            postRollTextList.Add("Gain 20 gold.");
        }
        else // Super High outcome
        {
            moneyToAdd = 20;

            postRollTextList.Add("The treasure chest is practically overflowing with gold!");
            postRollTextList.Add("Gain 20 gold.");
        }

        return new Vector3Int(moneyToAdd, healthToAdd, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
