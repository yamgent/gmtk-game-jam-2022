using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story3 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "In a random shop somwhere in the galaxy..",
            "It takes more than just luck to be a successful pirate. You need gear.",
            "I hope I can find something useful amongst these junk.",
            "(Sounds of gunfire)"
        };
    }
}
