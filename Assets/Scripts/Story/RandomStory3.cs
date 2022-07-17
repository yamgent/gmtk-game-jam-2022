using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory3 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "The space police are getting active in the area.",
            "You quickly leave the area, without anyone noticing."
        };
    }

    public override List<int> GetStoryImageList() {
        return null;
    }
}
