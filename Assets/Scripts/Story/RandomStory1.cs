using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory1 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "There does not seem to be anything left to do on this planet.",
            "You move to a nearby planet in search of gold."
        };
    }

    public override List<int> GetStoryImageList() {
        return null;
    }
}
