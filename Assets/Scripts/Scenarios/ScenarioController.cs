using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenarioController : MonoBehaviour
{
    public ScenarioCard scenarioStoryCard;
    public ScenarioCard scenarioCard1;
    public ScenarioCard scenarioCard2;
    public ScenarioOverlay scenarioOverlay;
    public DialogueAnimation dialogueAnimation;
    public TMP_Text healthNumberText;
    public TMP_Text diceNumberText;
    public TMP_Text goldNumberText;

    public void Start()
    {
        IntializeScenarioCards();
        UpdateResourcesUI();
        
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

    private void UpdateResourcesUI()
    {
        healthNumberText.text = Player.Instance.Health.ToString();
        diceNumberText.text = Player.Instance.Dice.ToString();
        goldNumberText.text = Player.Instance.Gold.ToString();
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
        scenarioCard2.SetScenarioText(new RobFarmerRandomScenario());
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
        Player.Instance.Dice -= numDice;
        int finalRoll = 0;
        for (int i = 0; i < numDice; ++i)
        {
            finalRoll += Random.Range(1, 7);
        }

        Vector3Int result = scenario.GetRollResult(finalRoll);
        Debug.Log("[NumDice: " + numDice + ", Roll: " + finalRoll + "] Gold += " + result.x + ", Health += " + result.y + ", Dice += " + result.z);
        Player.Instance.Gold += result.x;
        Player.Instance.Health += result.y;
        Player.Instance.Dice += result.z;

        dialogueAnimation.SetDialogue(scenario.GetPostRollTextList());
        UpdateResourcesUI();
    }
}
