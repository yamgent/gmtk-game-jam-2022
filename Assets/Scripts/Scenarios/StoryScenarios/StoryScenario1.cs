using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScenario1 : BaseScenario
{
    public override string title { get { return "Sudden Pirate Attack!"; } }
    public override string rewardsString { get { return "None"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 5;} }
    public override int maxSuccess { get { return 7; } }
    public override int highRoll { get { return 8;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "Two pirates have kicked down the door to your house and are ready for a fight." +
            "Time to teach them a lesson.\n" +
            "The number of dice you use represent the amount of power and luck. " +
            "Be warned that using too much power is not always good..";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int goldToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            goldToAdd = -10090;

            postRollTextList.Add("The two pirates quickly overwhelm you and take most of your money. The only remaining money you have is in your pocket.");
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            goldToAdd = -10090;

            postRollTextList.Add("The two pirates quickly overwhelm you and take most of your money. The only remaining money you have is in your pocket.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            goldToAdd = -10000;

            postRollTextList.Add("You beat up the two pirates and quickly take as much monies as you can hold and escape to your ship parked outside.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            goldToAdd = -10090;

            postRollTextList.Add("You quickly grab your gun and shoot the trespassers. Their screams alert their nearby comrades, who quickly overwhelm you and take your money.");
            postRollTextList.Add("The only remaining money you have is in your pocket.");
        }
        else // Super High outcome
        {
            goldToAdd = -10090;

            postRollTextList.Add("You quickly grab your gun and shoot the trespassers. Their screams alert their nearby comrades, who quickly overwhelm you and take your money.");
            postRollTextList.Add("The only remaining money you have is in your pocket.");
        }

        postRollTextList.Add("You lost your life savings. " + goldToAdd + " gold.");
        postRollTextList.Add("Curse those pirates. My life savings are gone!");
        postRollTextList.Add("Now I am unable to retire. Seems like my life of pirating must continue..");
        postRollTextList.Add("Starting the engine of your ship, you fly off into space to find new victims.. and hopefully find those pirates for some payback");

        return new Vector3Int(goldToAdd, 0, 0);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
