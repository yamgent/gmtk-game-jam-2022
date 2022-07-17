using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobDrunkardRandomScenario : BaseScenario
{
    public override string title { get { return "Rob a drunkard"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 3; } }
    public override int minSuccess { get { return 5;} }
    public override int maxSuccess { get { return 8; } }
    public override int highRoll { get { return 11;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You spot a drunkard with a fat wallet. He will be easy pickings.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        postRollTextList.Add("You attempt to pickpocket the drunkard.");
        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            healthToAdd = -8;

            postRollTextList.Add("He notices you and beats you up with his Kung Fu");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 25;
            healthToAdd = -5;

            postRollTextList.Add("He notices you and lands a few punches on you, before you escape with his wallet.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 25;

            postRollTextList.Add("You managed to steal his wallet.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            healthToAdd = -8;

            postRollTextList.Add("He notices you and beats you up with his Kung Fu.");
            postRollTextList.Add("You attempt to fight back, but his erratic drunken movements are too much for you to handle.");
        }
        else // Super High outcome
        {
            moneyToAdd = 25;
            healthToAdd = -5;

            postRollTextList.Add("He notices you and beats you up with his Kung Fu.");
            postRollTextList.Add("You fight back and knock him out. You quickly take his wallet and leave.");
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
