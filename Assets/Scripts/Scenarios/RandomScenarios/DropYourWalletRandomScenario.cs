using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropYourWalletRandomScenario : BaseScenario
{
    public override string title { get { return "Drop Your Wallet"; } }
    public override string rewardsString { get { return "Gold"; } }
    public override int lowRoll { get { return 1; } }
    public override int minSuccess { get { return 4;} }
    public override int maxSuccess { get { return 5; } }
    public override int highRoll { get { return 7;} }

    private List<string> postRollTextList;

    public override string GetDescription()
    {
        return "You accidentally dropped your wallet somewhere.";
    }

    public override Vector3Int GetRollResult(int rolledNumber)
    {
        postRollTextList = new List<string>();
        int moneyToAdd = 0;
        int healthToAdd = 0;
        int diceToAdd = 0;

        if (rolledNumber >= 1 && rolledNumber < lowRoll) // Super Low outcome
        {
            // Not possible.
        }
        else if (rolledNumber >= lowRoll && rolledNumber < minSuccess) // Low outcome
        {
            moneyToAdd = -20;

            postRollTextList.Add("You could not find your wallet after much searching.");
            postRollTextList.Add("Lose " + (-moneyToAdd) + " gold.");
        }
        else if (rolledNumber >= minSuccess && rolledNumber < maxSuccess) // Success outcome
        {
            postRollTextList.Add("You found your wallet.");
        }
        else if (rolledNumber >= maxSuccess && rolledNumber < highRoll) // High outcome
        {
            moneyToAdd = -rolledNumber * 2;
            
            postRollTextList.Add("Some kind stranger found your wallet and returned it to you. Unfortunately, the stranger took some gold before returning it to you.");
            postRollTextList.Add("Lose " + (-moneyToAdd) + " gold.");
        }
        else // Super High outcome
        {
            moneyToAdd = 5;
            diceToAdd = 1;
            
            postRollTextList.Add("After much searching, you found another wallet. It containes more gold than yours.");
            postRollTextList.Add("Gain " + moneyToAdd + " gold. Gain " + diceToAdd + "dice.");
        }

        return new Vector3Int(moneyToAdd, healthToAdd, diceToAdd);
    }

    public override List<string> GetPostRollTextList()
    {
        return postRollTextList;
    }
}
