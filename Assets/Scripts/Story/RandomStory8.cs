using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory8 : BaseStory
{
    public override BackgroundManager.BackgroundType GetBackgroundType()
    {
        return BackgroundManager.BackgroundType.Random;
    }

    public override List<string> GetStoryTextList()
    {
        return new List<string> {
            "You stop by a nearby trading hub to stock up on supplies."
        };
    }
}
