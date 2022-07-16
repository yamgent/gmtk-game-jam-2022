using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenarioOverlay : MonoBehaviour
{
    public RollVisual rollVisual;
    public DiceArea diceArea;

    public void Show(BaseScenario scenario)
    {
        gameObject.SetActive(true);
        rollVisual.InitializeRollVisual(scenario);

        // TODO: Dice roll details

        // TODO: Get nicely parsed result string from BaseScenario
    }

    public void NumDiceChanged()
    {
        rollVisual.NumDiceChanged(diceArea.numDice);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
