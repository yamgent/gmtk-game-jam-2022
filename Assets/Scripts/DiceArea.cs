using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceArea : MonoBehaviour
{
    public TMP_Text numDiceText;
    public int maxDice = 4;
    public int numDice = 1;

    public void ResetDice()
    {
        numDice = 1;
        numDiceText.text = numDice.ToString();
    }
    
    public void IncreaseDice()
    {
        numDice = Mathf.Min(Mathf.Min(maxDice, Player.Instance.Dice), numDice + 1);
        numDiceText.text = numDice.ToString();
    }

    public void DecreaseDice()
    {
        numDice = Mathf.Max(1, numDice - 1);
        numDiceText.text = numDice.ToString();
    }
}
