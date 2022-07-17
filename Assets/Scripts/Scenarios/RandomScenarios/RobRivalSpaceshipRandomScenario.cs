using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobRivalSpaceshipRandomScenario : BaseScenario
{
    public override string title { get { return "Rob Rival Spaceship"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 3; } }
    public override int minSuccess { get { return 7;} }
    public override int maxSuccess { get { return 10; } }
    public override int highRoll { get { return 12;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "A rival pirate spaceship is escaping after robbing a bank.\n" +
            "This could be the perfect chance to make some money.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            healthToAdd = -4;

            postRollTextList.Add("You got outmanoeuvred by the enemy as they shot you with their cannons.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = rolledNumber;

            postRollTextList.Add("The enemy threw out a large chest of gold, presumably to lighten the load.");
            postRollTextList.Add("Upon retrieving the chest, you realized that you were tricked. There is only a pitiful amount of gold in the chest.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = rolledNumber * 2;

            postRollTextList.Add("You managed to corner the pirates, and they offered to share the loot if you stopped attacking.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 25;
            diceToAdd = 1;

            postRollTextList.Add("You managed to corner the pirates and heavily damage their ship. They offered to give you the loot if you spared their lives.");
        }
        else // Super High outcome
        {
            postRollTextList.Add("Your cannon hit the engine and blew up the entire ship, leaving nothing behind.");
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
