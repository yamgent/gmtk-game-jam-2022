using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScenario
{
    public abstract string title { get; }
    public abstract string rewardsString { get; }
    public abstract int lowRoll { get; }
    public abstract int minSuccess { get; }
    public abstract int maxSuccess { get; }
    public abstract int highRoll { get; }

    public abstract string GetDescription();

    // return in the format: Vector3Int(Gold, Health, Money)
    public abstract Vector3Int GetRollResult(int rolledNumber);

    public abstract List<string> GetPostRollTextList();

    public string GetTitle()
    {
        return title;
    }

    public string GetSuccessCondition()
    {
        return minSuccess + " - " + maxSuccess;
    }

    public string GetRewardType()
    {
        return rewardsString; 
    }
}
