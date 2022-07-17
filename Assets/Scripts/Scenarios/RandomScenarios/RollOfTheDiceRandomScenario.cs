using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOfTheDiceRandomScenario : BaseScenario
{
    public override string title { get { return "Roll of the Dice"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 6;} }
    public override int maxSuccess { get { return 7; } }
    public override int highRoll { get { return 99;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Some punks on the streets are gambling with dice. \"Only 1 dice allowed.\"";
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
            moneyToAdd = -20;

            postRollTextList.Add("You lose the bet.");
            postRollTextList.Add("Lose " + (-moneyToAdd) + " gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 20;

            postRollTextList.Add("You win the bet.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            // Not possible.
        }
        else // Super High outcome
        {
            // Not possible.
        }

        return new Vector3Int(moneyToAdd, healthToAdd, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
