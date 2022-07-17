using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory4 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        //return randomStories[Random.Range(0, randomStories.Length)];
        return new List<string> {
            "Your travels have taken a toll on the ship.",
            "You stop by the nearest city for repairs."
        };
    }
}
