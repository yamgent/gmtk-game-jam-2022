using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "Random filler text..",
            "Please replace with proper text!"
        };
    }
}
