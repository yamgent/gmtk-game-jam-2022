using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RansomRichKidRandomScenario : BaseScenario
{
    public override string title { get { return "Ransom Rich Kid"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 10; } }
    public override int minSuccess { get { return 18;} }
    public override int maxSuccess { get { return 21; } }
    public override int highRoll { get { return 25;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Kidnap a rich kid and ask their family for ransom.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            healthToAdd = -10;

            postRollTextList.Add("The rich kid's parents set a trap for you at the meeting point.");
            postRollTextList.Add("Lose " + (-healthToAdd) + " health.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 50;

            postRollTextList.Add("The rich kid's parents haggled for a lower ransom.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 100;

            postRollTextList.Add("The rich kid's parents agreed to pay the ransom.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 100;
            healthToAdd = -rolledNumber;

            postRollTextList.Add("The rich kid's parents agreed to pay the ransom, but space cops were present at the meeting point. You escape after a long fight.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold. Lose " + (-healthToAdd) + " health.");
        }
        else // Super High outcome
        {
            moneyToAdd = 100 - rolledNumber;

            postRollTextList.Add("The rich kid's parents agree to pay the ransom, but space cops were present at the meeting point. You secretly grab however much gold you can and avoid a fight.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }

        return new Vector3Int(moneyToAdd, healthToAdd, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
