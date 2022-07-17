using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory4 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "Your travels have taken a toll on the ship.",
            "You stop by the nearest city for repairs."
        };
    }

    public override List<int> GetStoryImageList() {
        return new List<int> { 4, -1 };
    }
}
