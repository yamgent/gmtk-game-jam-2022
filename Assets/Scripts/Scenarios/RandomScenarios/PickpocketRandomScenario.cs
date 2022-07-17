using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickpocketRandomScenario : BaseScenario
{
    public override string title { get { return "Pickpocket"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 2;} }
    public override int maxSuccess { get { return 6; } }
    public override int highRoll { get { return 7;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "A pickpocket bumped into you and took some of your gold.";
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

            postRollTextList.Add("You lost the pickpocket in the crowd.");
            postRollTextList.Add("Lose " + (-moneyToAdd) + " gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            postRollTextList.Add("You caught the pickpocket and beat him up before retrieving your gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = -20;

            postRollTextList.Add("You drew your weapon and shot the pickpocket dead. You could not retrieve your gold as the space cops were after you.");
            postRollTextList.Add("Lose " + (-moneyToAdd) + " gold.");
        }
        else // Super High outcome
        {
            moneyToAdd = -20;

            postRollTextList.Add("You drew your weapon and shot the pickpocket dead. You could not retrieve your gold as the space cops were after you.");
            postRollTextList.Add("Lose " + (-moneyToAdd) + " gold.");
        }

        return new Vector3Int(moneyToAdd, healthToAdd, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
