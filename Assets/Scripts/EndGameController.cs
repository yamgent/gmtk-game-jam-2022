using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameController : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text healthText;
    public TMP_Text diceText;
    public TMP_Text goldText;
    public TMP_Text scoreSummaryText;

    // Start is called before the first frame update
    void Start()
    {
        if (Player.Instance.Health == 0)
        {
            titleText.text = "You bled to death.";
        }
        else if (Player.Instance.Dice == 0)
        {
            titleText.text = "You have no more dice left.";
        }
        else
        {
            titleText.text = "You conquered the galaxy. You are the strongest and richest pirate ever lived.";
        }

        healthText.text = Player.Instance.Health.ToString();
        if (Player.Instance.Health == 0)
        {
            healthText.color = Color.red;
        }

        diceText.text = Player.Instance.Dice.ToString();
        if (Player.Instance.Dice == 0)
        {
            diceText.color = Color.red;
        }

        goldText.text = Player.Instance.Gold.ToString();

        if (Player.Instance.Gold < 0)
        {
            scoreSummaryText.text = "You are destined for a poor life. :(";
        }
        else if (Player.Instance.Gold < 100)
        {
            scoreSummaryText.text = "Well at least you had the time of your life.";
        }
        else if (Player.Instance.Gold < 200)
        {
            scoreSummaryText.text = "It's ain't much, but it's honest work.";
        }
        else
        {
            scoreSummaryText.text = "Coming back from retirement was a right choice all along.";
        }
    }
}
