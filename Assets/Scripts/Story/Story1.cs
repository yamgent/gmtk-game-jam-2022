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
            "Pirating is a very lucrative profession.",
            "My coffers are filled to the brim with gold.",
            "I can safely retire now, after many long years.",
            "(Sounds of gunfire)"
        };
    }
}
