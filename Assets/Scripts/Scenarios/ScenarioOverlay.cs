using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenarioOverlay : MonoBehaviour
{
    public TMP_Text targetRollText;
    public TMP_Text yourRollText;
    public TMP_Text resultText;

    public void Show(BaseScenario scenario)
    {
        gameObject.SetActive(true);
        targetRollText.text = scenario.minSuccess + " - " + scenario.maxSuccess;

        // TODO: Dice roll details

        // TODO: Get nicely parsed result string from BaseScenario
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
