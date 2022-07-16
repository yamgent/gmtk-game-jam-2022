using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public List<BaseStory> storyList;
    public List<BaseScenario> scenarioList;
    public int index;
    public int numRandomScenario;
    public bool isStoryScenario;
    public bool isStory;
    public bool isFinalScenario;

    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        index = 0;
        numRandomScenario = 2;
        isStoryScenario = true;
        isStory = true;
        storyList = new List<BaseStory> { new Story1(), new Story2(), new Story3() };
        scenarioList = new List<BaseScenario> { new StoryScenario1(), new StoryScenario2(), new StoryScenario3() };
    }

    public void SwitchStoryAndScenario() {
        if (isStory) {
            setToScenario();
        } else {
            setToStory();
        }

        isStory = !isStory;
    }

    public void StartLoseScene() {
        // TODO: Animate this?
        SceneManager.LoadScene("EndScene");
    }

    private void setToScenario() {
        SceneManager.LoadScene("GameScene");
    }

    private void setToStory() {
        if (isStoryScenario && index < storyList.Count - 1) {
            index++;
            numRandomScenario = Random.Range(3, 6);
        } else {
            numRandomScenario--;
        }

        SceneManager.LoadScene("StoryScene");
    }
}
