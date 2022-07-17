using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story1 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        return new List<string> {
            "On home planet..",
            "It is the year 30XX.",
            "I was once a great space pirate.",
            "Pirating is a very lucrative profession, and my coffers are filled to the brim with gold.",
            "I can safely retire now, after many long years.",
            "(Sounds of gunfire)"
        };
    }

    public override List<int> GetStoryImageList() {
        return new List<int> { -1, -1, -1, 0, -1, 1 };
    }
}
