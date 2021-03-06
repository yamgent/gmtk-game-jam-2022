using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story2 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "On a planet's Dice mines..",
            "In this world, dice provide power and luck to the user, enhancing their abilities.",
            "Without any dice, no scenario will play out in your favour.",
            "Dice are, without a doubt, the most important item for a pirate."
        };
    }

    public override List<int> GetStoryImageList() {
        return new List<int> { -1, 2, -1, -1 };
    }
}
