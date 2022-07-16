using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScenario2 : BaseScenario
{
    public override string title { get { return "Infiltrate the Dice Mines"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 0; } }
    public override int minSuccess { get { return 4;} }
    public override int maxSuccess { get { return 9; } }
    public override int highRoll { get { return 12;} }

    public override List<string> GetPreRollTextList()
    {
        return new List<string> {
            "On a planet's Dice mines",
            "In this world, dice provide power and luck to the user, enhancing their abilities.",
            "Without any dice, no scenario will play out in your favour.",
            "Sneak into the dice mines and steal the loot"
        };
    }

    public override void PerformRollResult(int rolledNumber)
    {
        if (rolledNumber <= 3)
        {
            //gain X-1 dice
        }
        else if (rolledNumber <= 8)
        {
            //gain X dice
        }
        else
        {
            //gain X/2 dice
        }
    }

    public override List<string> GetPostRollTextList(int rolledNumber)
    {
        List<string> postRollTextList = new List<string>();
        if (rolledNumber <= 3)
        {
            postRollTextList.Add("Successfully stole as many dice as possible before escaping quietly");
        }
        else if (rolledNumber <= 8)
        {
            postRollTextList.Add("Guards are onto you. Escape despite only stealing a few dice");
        }
        else
        {
            postRollTextList.Add("Took too much dice and alerted the guards. Dropped half of the stolen dice while escaping");
        }
        postRollTextList.Add("That was a good haul of dice. Could have been better, but still good. I should get out of here before the guards find me.");
        return postRollTextList;
    }
}
