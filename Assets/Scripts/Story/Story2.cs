using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story2 : BaseStory
{
    public override BackgroundManager.BackgroundType GetBackgroundType()
    {
        return BackgroundManager.BackgroundType.Scene2;
    }

    public override List<string> GetStoryTextList()
    {
        return new List<string> {
            "On a planet's Dice mines..",
            "In this world, dice provide power and luck to the user, enhancing their abilities.",
            "Without any dice, no scenario will play out in your favour.",
            "Dice are, without a doubt, the most important item for a pirate."
        };
    }
}
