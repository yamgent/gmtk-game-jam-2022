using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory6 : BaseStory
{
    public override BackgroundManager.BackgroundType GetBackgroundType()
    {
        return BackgroundManager.BackgroundType.Random;
    }

    public override List<string> GetStoryTextList()
    {
        return new List<string> {
            "You heard rumors of people getting rich in this area.",
            "You travelled all the way out here to find and rob them."
        };
    }
}
