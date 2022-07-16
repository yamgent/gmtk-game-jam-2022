using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenarioCard : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text conditionText;

    private ScenarioController parent;
    private BaseScenario scenario;

    public void SetScenarioController(ScenarioController parent) 
    {
        this.parent = parent;
    }

    public void SetScenarioText(BaseScenario scenario)
    {
        this.scenario = scenario;

        titleText.text = scenario.GetTitle();
        conditionText.text = scenario.GetConditionDescription();
    }

    public void TriggerScenario()
    {
        parent.ShowScenarioOverlay(scenario);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
