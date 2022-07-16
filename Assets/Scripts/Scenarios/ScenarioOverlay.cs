using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenarioOverlay : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text description;

    public RollVisual rollVisual;
    public DiceArea diceArea;

    public void Show(BaseScenario scenario)
    {
        gameObject.SetActive(true);

        title.text = scenario.title;
        description.text = "placeholder";

        rollVisual.InitializeRollVisual(scenario);
        diceArea.ResetDice();
        NumDiceChanged();

        // TODO: Dice roll details

        // TODO: Get nicely parsed result string from BaseScenario
    }

    public void NumDiceChanged()
    {
        rollVisual.UpdateRollVisual(diceArea.numDice);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
