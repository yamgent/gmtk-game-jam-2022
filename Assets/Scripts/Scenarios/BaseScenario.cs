using System.Collections;
using System.Collections.Generic;

public abstract class BaseScenario
{
    public abstract string title { get; }
    public abstract string rewardsString { get; }
    public abstract int lowRoll { get; }
    public abstract int minSuccess { get; }
    public abstract int maxSuccess { get; }
    public abstract int highRoll { get; }

    public abstract List<string> GetPreRollTextList();

    public abstract void PerformRollResult(int rolledNumber);

    public abstract List<string> GetPostRollTextList(int rolledNumber);

    public string GetTitle()
    {
        return title;
    }

    public string GetConditionDescription()
    {
        return "Success Condition\n" +
            minSuccess + " - " + maxSuccess + "\n\n" +
            "Possible Rewards\n" +
            rewardsString; 
    }
}
