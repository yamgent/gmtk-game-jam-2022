using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory2 : BaseStory
{
    public override List<string> GetStoryTextList() 
    {
        //return randomStories[Random.Range(0, randomStories.Length)];
        return new List<string> {
           "After wandering for a long time, you stumble upon a small village."
        };
    }
}
