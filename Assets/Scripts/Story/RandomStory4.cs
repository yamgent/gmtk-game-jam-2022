using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory4 : BaseStory
{
    public override BackgroundManager.BackgroundType GetBackgroundType()
    {
        return BackgroundManager.BackgroundType.Random;
    }

    public override List<string> GetStoryTextList()
    {
        return new List<string> {
            "Your travels have taken a toll on the ship.",
            "You stop by the nearest city for repairs."
        };
    }
}
