using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    public Text scenarioTextObject;
    public ScenarioCard scenarioStoryCard;
    public ScenarioCard scenarioCard1;
    public ScenarioCard scenarioCard2;
    public ScenarioOverlay scenarioOverlay;

    private BaseScenario currentScenario;
    private int currentTextIndex;
    private int rollTextIndex;
    private int lastTextIndex;
    private int rolledNumber;

    public void Start()
    {
        IntializeScenarioCards();
        LoadRandomScenario();
    }

    private void IntializeScenarioCards()
    {
        scenarioStoryCard.SetScenarioController(this);
        scenarioCard1.SetScenarioController(this);
        scenarioCard2.SetScenarioController(this);
        scenarioOverlay.SetScenarioController(this);
    }

    private void LoadStoryScenario()
    {
        scenarioStoryCard.Show();
        scenarioCard1.Hide();
        scenarioCard2.Hide();
    }

    private void LoadRandomScenario()
    {
        scenarioStoryCard.Hide();
        scenarioCard1.Show();
        scenarioCard2.Show();

        GenerateRandomScenario();
    }

    private void GenerateNextStoryScenario()
    {
        // TODO
    }

    private void GenerateRandomScenario()
    {
        // TODO: generate 2 random scenarios from 2 different categories
        // For now, hardcoded
        scenarioCard1.SetScenarioText(new RobCleaningRobotRandomScenario());
        scenarioCard2.SetScenarioText(new StoryScenario2());
    }

    public void ShowScenarioOverlay(BaseScenario scenario)
    {
        scenarioOverlay.Show(scenario);
    }

    public void HideScenarioOverlay()
    {
        scenarioOverlay.Hide();
    }

    public void ResolveScenario(BaseScenario scenario, int numDice)
    {
        int finalRoll = 0;
        for (int i = 0; i < numDice; ++i)
        {
            finalRoll += Random.Range(1, 7);
        }

        Vector3Int result = scenario.GetRollResult(finalRoll);
        Debug.Log("[Roll: " + finalRoll + "] Gold += " + result.x + ", Health += " + result.y + ", Dice += " + result.z);
    }

    /*public void StartScenario(BaseScenario scenario)
    {
        currentScenario = scenario;
        currentTextIndex = -1;
        rollTextIndex = currentScenario.GetDescription().Count - 1;
        lastTextIndex = 99999; // Will be updated after dice roll.
        rolledNumber = -1;
    }

    public void Next()
    {
        currentTextIndex++;
        if (currentTextIndex <= rollTextIndex)
        {
            scenarioTextObject.text = currentScenario.GetDescription()[currentTextIndex];
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

    public void RollDice()
    {
        // TODO: roll dice here.
        rolledNumber = 123;
        currentScenario.PerformRollResult(rolledNumber);
        lastTextIndex = rollTextIndex + currentScenario.GetPostRollTextList(rolledNumber).Count;
    }*/
}
