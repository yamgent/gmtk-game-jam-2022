using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public List<BaseStory> storyList;
    public List<BaseScenario> scenarioList;
    public bool isStoryScene;
    public int index;

    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        isStoryScene = true;
        index = 0;
        storyList = new List<BaseStory> { new Story1() };
        scenarioList = new List<BaseScenario> { new RobCleaningRobotRandomScenario() };
    }

    public void setToScenario() {
        isStoryScene = false;
    }

    public void setToStory() {
        isStoryScene = true;
        index++;
    }
}
