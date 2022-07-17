using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHuntingRandomScenario : BaseScenario
{
    public override string title { get { return "Bounty Hunting"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 10; } }
    public override int minSuccess { get { return 18;} }
    public override int maxSuccess { get { return 21; } }
    public override int highRoll { get { return 25;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Bounty hunting seems lucrative, why not give it a try?";
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

            postRollTextList.Add("You failed to capture the target. He was far more skilled than expected.");
            postRollTextList.Add("Lose " + (-healthToAdd) + " health.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 50;

            postRollTextList.Add("It was a tough fight. You shared the reward with the other bounty hunters.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 100;

            postRollTextList.Add("You captured the target.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 100;
            healthToAdd = -rolledNumber;

            postRollTextList.Add("You captured the target, but broke an arm in the process.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold. Lose " + (-healthToAdd) + " health.");
        }
        else // Super High outcome
        {
            moneyToAdd = 100;
            healthToAdd = -rolledNumber;

            postRollTextList.Add("You captured the target, but broke an arm in the process.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold. Lose " + (-healthToAdd) + " health.");
        }

        return new Vector3Int(moneyToAdd, healthToAdd, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
