using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceArea : MonoBehaviour
{
    public Dice[] dice;
    public int numDice = 1;

    private int[] rollValues;

    public void ResetDice()
    {
        numDice = Mathf.Min(1, Player.Instance.Dice); // Could be 0.
        rollValues = new int[dice.Length];

        ShowDice();
    }

    public void PlayDiceAnimation()
    {
        float startDelay = 0f;

        for (int i = 0; i < numDice; ++i)
        {
            StartCoroutine(StartAnimation(startDelay, i));
            startDelay += 0.1f;
        }
    }

    private IEnumerator StartAnimation(float startDelay, int index)
    {
        yield return new WaitForSeconds(startDelay);

        dice[index].PlayAnimation(rollValues[index]);
    }
    
    public void IncreaseDice()
    {
        numDice =
            Mathf.Min(
              Mathf.Min(Player.Instance.Dice, dice.Length),
              numDice + 1);
        ShowDice();
    }

    public void SetRollValue(int index, int value)
    {
        rollValues[index] = value;
    }

    public void DecreaseDice()
    {
        numDice = Player.Instance.Dice == 0 ? 0 : Mathf.Max(1, numDice - 1);
        ShowDice();
    }

    private void ShowDice()
    {
        for (int i = 0; i < dice.Length; ++i)
        {
            dice[i].Hide();
        }

        for (int i = 0; i < numDice; ++i)
        {
            dice[i].Show();
        }
    }
}
