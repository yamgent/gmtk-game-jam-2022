using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScenario2 : BaseScenario
{
    public override string title { get { return "Infiltrate the Dice Mines"; } }
    public override string rewardsString { get { return "Dice"; } }
    public override int lowRoll { get { return 0; } }
    public override int minSuccess { get { return 4;} }
    public override int maxSuccess { get { return 9; } }
    public override int highRoll { get { return 12;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Sneak into the mines and steal as much dice as you can.\n" +
            "Dice are an important resource in your journey. You will be unable to continue if you run out of dice. " +
            "Use them carefully..";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            diceToAdd = rolledNumber - 1;

            postRollTextList.Add("Guards are onto you. Escape despite only stealing a few dice.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            diceToAdd = rolledNumber - 1;

            postRollTextList.Add("Guards are onto you. Escape despite only stealing a few dice.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            diceToAdd = rolledNumber;

            postRollTextList.Add("Successfully stole as many dice as possible before escaping quietly.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            diceToAdd = rolledNumber / 2;

            postRollTextList.Add("Took too much dice and alerted the guards. Dropped half of the stolen dice while escaping.");
        }
        else // Super High outcome
        {
            diceToAdd = rolledNumber / 2;

            postRollTextList.Add("Took too much dice and alerted the guards. Dropped half of the stolen dice while escaping.");
        }

        postRollTextList.Add("That was a good haul of dice. Gained " + diceToAdd + " dice.");
        postRollTextList.Add("Could have been better, but still good. I should get out of here before the guards find me.");

        return new Vector3Int(0, 0, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
