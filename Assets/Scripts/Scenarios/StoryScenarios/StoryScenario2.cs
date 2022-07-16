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

    private int diceToAdd = 0;

    public override string GetDescription()
    {
        return "On a planet's Dice mines.\n" +
            "In this world, dice provide power and luck to the user, enhancing their abilities. " +
            "Without any dice, no scenario will play out in your favour.\n" +
            "Sneak into the dice mines and steal the loot";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {

        if (rolledNumber <= 3)
        {
            diceToAdd = rolledNumber - 1;
        }
        else if (rolledNumber <= 8)
        {
            diceToAdd = rolledNumber;
        }
        else
        {
            diceToAdd = rolledNumber / 2;
        }

        return new Vector3Int(0, 0, diceToAdd);
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
