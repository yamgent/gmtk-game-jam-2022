using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStory
{
    public abstract List<string> GetStoryTextList();
    public abstract BackgroundManager.BackgroundType GetBackgroundType();
}
