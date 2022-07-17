using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story3 : BaseStory
{
    public override BackgroundManager.BackgroundType GetBackgroundType()
    {
        return BackgroundManager.BackgroundType.Scene3;
    }

    public override List<string> GetStoryTextList()
    {
        return new List<string> {
            "In a random shop somewhere in the galaxy..",
            "It takes more than just luck to be a successful pirate. You need gears.",
            "I hope I can find something useful amongst these junk.",
            "(Sounds of gunfire)"
        };
    }
}
