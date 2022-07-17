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

    private List<BaseScenario> goldRandomScenarioList = new List<BaseScenario> {
        new BountyHuntedRandomScenario(),
        new BountyHuntingRandomScenario(),
        new DropYourWalletRandomScenario(),
        new GreatHeistRandomScenario(),
        new HopelesslyInLoveRandomScenario(),
        new MaintenanceNegligenceRandomScenario(),
        new PickpocketRandomScenario(),
        new PirateVsPirateRandomScenario(),
        new RaidAsteroidRigRandomScenario(),
        new RansomRichKidRandomScenario(),
        new RobCleaningRobotRandomScenario(),
        new RobFarmerRandomScenario(),
        new RobRivalSpaceshipRandomScenario(),
        new RobSpacePoliceRandomScenario(),
        new RollOfTheDice2RandomScenario(),
        new RollOfTheDiceRandomScenario(),
        new SaboteurRandomScenario(),
        new TreasureChestRandomScenario()
    };
    private List<BaseScenario> healthRandomScenarioList = new List<BaseScenario> {
        new ArrrPiratesRandomScenario(),
        new GetWoundsTreatedRandomScenario(),
        new MiracleDrugRandomScenario(),
        new PestInfestationRandomScenario(),
        new PositivityRandomScenario(),
        new QuackEncounterRandomScenario(),
        new RAndRRandomScenario(),
        new RobotAssassinRandomScenario()
    };
    private List<BaseScenario> diceRandomScenarioList = new List<BaseScenario> {
        new LuckyRandomScenario(),
        new MineDiceReservesRandomScenario(),
        new OpenedWindowsRandomScenario(),
        new DiceCloningMachineRandomScenario(),
        new UndergroundCasinoRandomScenario(),
        new SecretDiceMinesRandomScenario()
    };

    public void Start()
    {
        IntializeScenarioCards();
        UpdateResourcesUI();

        if (GameController.Instance.isStoryScenario)
        {
            LoadStoryScenario(GameController.Instance.scenarioList[GameController.Instance.index], GameController.Instance.index);
            GameController.Instance.isStoryScenario = false;
        }
        else
        {
            LoadRandomScenario();
            GameController.Instance.SetIsStoryScenario();
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

    private void LoadStoryScenario(BaseScenario scenario, int storyIndex)
    {
        scenarioStoryCard.Show();
        scenarioCard1.Hide();
        scenarioCard2.Hide();

        scenarioStoryCard.SetScenarioText(scenario);
        BackgroundManager.GetSingleton().SetStoryBackground(storyIndex);
    }

    private void LoadRandomScenario()
    {
        scenarioStoryCard.Hide();
        scenarioCard1.Show();
        scenarioCard2.Show();

        GenerateRandomScenario();
        BackgroundManager.GetSingleton().SetRandomBackground();
    }

    private void GenerateRandomScenario()
    {
        List<List<BaseScenario>> randomScenarioList = new List<List<BaseScenario>> {
            goldRandomScenarioList,
            healthRandomScenarioList,
            diceRandomScenarioList
        };
        randomScenarioList.RemoveAt(Random.Range(0, 3));

        scenarioCard1.SetScenarioText(randomScenarioList[0][Random.Range(0, randomScenarioList[0].Count)]);
        scenarioCard2.SetScenarioText(randomScenarioList[1][Random.Range(0, randomScenarioList[1].Count)]);
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
        if (numDice == 0) {
            // The player clicked "Roll" with no dice.
            GameController.Instance.StartLoseScene();
            return;
        }

        Player.Instance.Dice -= numDice;
        int finalRoll = 0;
        for (int i = 0; i < numDice; ++i)
        {
            int roll = Random.Range(1, 7);
            finalRoll += roll;
            scenarioOverlay.SetRollValue(i, roll);
        }

        Vector3Int result = scenario.GetRollResult(finalRoll);
        Debug.Log("[NumDice: " + numDice + ", Roll: " + finalRoll + "] Gold += " + result.x + ", Health += " + result.y + ", Dice += " + result.z);
        Player.Instance.Gold += result.x;
        Player.Instance.Health += result.y;
        Player.Instance.Dice += result.z;

        List<string> postRollTextList = new List<string> { "[Rolled " + finalRoll + "]" };
        postRollTextList.AddRange(scenario.GetPostRollTextList());
        dialogueAnimation.SetDialogue(postRollTextList);
        UpdateResourcesUI();
    }
}
