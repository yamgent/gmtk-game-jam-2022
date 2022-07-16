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
    public DialogueAnimation dialogueAnimation;

    public void Start()
    {
        IntializeScenarioCards();
        
        if (GameController.Instance.isStoryScenario)
        {
            LoadStoryScenario(GameController.Instance.scenarioList[GameController.Instance.index]);
            GameController.Instance.isStoryScenario = false;
        }
        else
        {
            LoadRandomScenario();
            if (GameController.Instance.numRandomScenario <= 0) GameController.Instance.isStoryScenario = true;
        }
    }

    private void IntializeScenarioCards()
    {
        scenarioStoryCard.SetScenarioController(this);
        scenarioCard1.SetScenarioController(this);
        scenarioCard2.SetScenarioController(this);
        scenarioOverlay.SetScenarioController(this);
    }

    private void LoadStoryScenario(BaseScenario scenario)
    {
        scenarioStoryCard.Show();
        scenarioCard1.Hide();
        scenarioCard2.Hide();

        scenarioStoryCard.SetScenarioText(scenario);
    }

    private void LoadRandomScenario()
    {
        scenarioStoryCard.Hide();
        scenarioCard1.Show();
        scenarioCard2.Show();

        GenerateRandomScenario();
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
        dialogueAnimation.SetDialogue(scenario.GetPostRollTextList());
    }
}
