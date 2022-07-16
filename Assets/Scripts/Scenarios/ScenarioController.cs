using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    public Text scenarioTextObject;

    private BaseScenario currentScenario;
    private int currentTextIndex;
    private int rollTextIndex;
    private int lastTextIndex;
    private int rolledNumber;

    public void StartScenario(BaseScenario scenario)
    {
        currentScenario = scenario;
        currentTextIndex = -1;
        rollTextIndex = currentScenario.GetPreRollTextList().Count - 1;
        lastTextIndex = 99999; // Will be updated after dice roll.
        rolledNumber = -1;
    }

    public void Next()
    {
        currentTextIndex++;
        if (currentTextIndex <= rollTextIndex)
        {
            scenarioTextObject.text = currentScenario.GetPreRollTextList()[currentTextIndex];
            if (currentTextIndex == rollTextIndex)
            {
                // TODO: show "roll dice" button here.
            }
        }
        else
        {
            scenarioTextObject.text = currentScenario.GetPostRollTextList(rolledNumber)[currentTextIndex - rollTextIndex];
            if (currentTextIndex == lastTextIndex)
            {
                // TODO: show "end scenario" button here.
            }
        }
    }

    public void RollDice(/* TODO: dice here */)
    {
        // TODO: roll dice here.
        rolledNumber = 123;
        currentScenario.PerformRollResult(rolledNumber);
        lastTextIndex = rollTextIndex + currentScenario.GetPostRollTextList(rolledNumber).Count;
    }
}
