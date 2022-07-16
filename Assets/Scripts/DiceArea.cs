using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceArea : MonoBehaviour
{
    public TMP_Text numDiceText;
    public int maxDice = 4;
    public int numDice = 1;
    
    public void IncreaseDice()
    {
        // TODO: Need to check with current number of dice also
        numDice = Mathf.Min(maxDice, numDice + 1);

        numDiceText.text = "" + numDice;
    }

    public void DecreaseDice()
    {
        numDice = Mathf.Max(1, numDice - 1);

        numDiceText.text = "" + numDice;
    }
}
