using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory8 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "You stop by a nearby trading hub to stock up on supplies."
        };
    }

    public override List<int> GetStoryImageList() {
        return null;
    }
}
