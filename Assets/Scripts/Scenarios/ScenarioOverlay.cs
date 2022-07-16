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
        
    private ScenarioController parent;
    private BaseScenario scenario;

    public void SetScenarioController(ScenarioController parent) 
    {
        this.parent = parent;
    }

    public void Show(BaseScenario scenario)
    {
        this.scenario = scenario;

        gameObject.SetActive(true);

        title.text = scenario.title;
        description.text = "placeholder";

        rollVisual.InitializeRollVisual(scenario);
        diceArea.ResetDice();
        NumDiceChanged();
    }

    public void RollDice()
    {
        parent.ResolveScenario(scenario, diceArea.numDice);
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
