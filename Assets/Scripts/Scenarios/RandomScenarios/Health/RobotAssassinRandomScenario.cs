using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAssassinRandomScenario : BaseScenario
{
    public override string title { get { return "Robot Assassin"; } }
    public override string rewardsString { get { return "Health"; } }
    public override int lowRoll { get { return 3; } }
    public override int minSuccess { get { return 10;} }
    public override int maxSuccess { get { return 12; } }
    public override int highRoll { get { return 15;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Seems like someone hired an assassin to get rid of you.";
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

            postRollTextList.Add("You are no match for the assassin.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            healthToAdd = -5;

            postRollTextList.Add("The assassin hit you with his gun, but you manage to escape.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            diceToAdd = 1;

            postRollTextList.Add("You dealt with the assassin and found some dice leftover.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 5;

            postRollTextList.Add("You dealt with the assassin and found some gold on him.");
        }
        else // Super High outcome
        {
            postRollTextList.Add("You dealt with the assassin. You searched his corpse but found nothing.");
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
