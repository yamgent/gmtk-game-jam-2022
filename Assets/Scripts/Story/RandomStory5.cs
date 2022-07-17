using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory5 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "Even veteran pirates have trouble reading maps.",
            "You are hopelessly lost in space."
        };
    }
}
