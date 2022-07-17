using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameController : MonoBehaviour
{
    public TMP_Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        if (Player.Instance.Health == 0) {
            titleText.text = "You bled to death.";
        } else if (Player.Instance.Dice == 0) {
            titleText.text = "You have no more die left.";
        } else {
            titleText.text = "You won!";
        }
    }
}
