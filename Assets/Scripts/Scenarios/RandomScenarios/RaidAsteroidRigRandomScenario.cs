using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidAsteroidRigRandomScenario : BaseScenario
{
    public override string title { get { return "Raid Asteroid Mining Rig"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 6; } }
    public override int minSuccess { get { return 8;} }
    public override int maxSuccess { get { return 9; } }
    public override int highRoll { get { return 11;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Asteroid mining rigs usually have a lot of gold. A prime target for pirates.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            moneyToAdd = -10;

            postRollTextList.Add("The miners were more skilled than expected and captured you. They offered to let you go if you paid them.");
            postRollTextList.Add("Lose " + (-moneyToAdd) + " gold.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = 10;

            postRollTextList.Add("Seems like the gold was recently transported off the asteroid.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            moneyToAdd = 40;

            postRollTextList.Add("Jackpot! The mined gold was not transported out yet.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = 10;

            postRollTextList.Add("Most of the gold was destroyed during the fight with the miners.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold.");
        }
        else // Super High outcome
        {
            postRollTextList.Add("The fuel station caught fire during the battle and exploded, destroying the entire asteroid.");
        }

        return new Vector3Int(moneyToAdd, healthToAdd, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
