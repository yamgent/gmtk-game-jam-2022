using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScenario3 : BaseScenario
{
    public override string title { get { return "Defeat the Bandits"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 2;} }
    public override int maxSuccess { get { return 6; } }
    public override int highRoll { get { return 8;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Help the shopkeeper by defeating the armed robbers!\n" +
            "It is always good to help merchants. Who knows? They may have something good to sell you.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int goldToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            goldToAdd = 0;

            postRollTextList.Add("You take aim at the bandits, but miss your shots. They hit the shelf behind the bandits, causing it to topple onto them. Shopkeeper thanks you for the help.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            goldToAdd = 0;

            postRollTextList.Add("You take aim at the bandits, but miss your shots. They hit the shelf behind the bandits, causing it to topple onto them. Shopkeeper thanks you for the help.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            goldToAdd = 5;

            postRollTextList.Add("Dispatched the bandits easily. They flee the shop.");
            postRollTextList.Add("Shopkeeper rewards you with some gold as thanks. Gained 5 gold.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            goldToAdd = 0;

            postRollTextList.Add("You shoot at the bandits and kill them all. Blood is splattered all over the shop. Shopkeeper thanks you for the help.");
        }
        else // Super High outcome
        {
            goldToAdd = 0;
            
            postRollTextList.Add("You shoot at the bandits and kill them all. Blood is splattered all over the shop. Shopkeeper thanks you for the help.");
        }

        postRollTextList.Add("You got shoo-ed out of the shop. Turns out all shops in the galaxy are not ready to open yet, due to time constraints..");

        return new Vector3Int(goldToAdd, 0, 0);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
