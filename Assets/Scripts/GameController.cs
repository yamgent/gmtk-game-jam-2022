using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public List<BaseStory> storyList;
    public int index;
    public bool isStoryScenario;
    public bool isStory;

    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        index = 0;
        isStoryScenario = true;
        isStory = true;
        storyList = new List<BaseStory> { new Story1() };
    }

    public void SwitchStoryAndScenario() {
        if (isStory) {
            setToScenario();
        } else {
            setToStory();
        }

        isStory = !isStory;
    }

    private void setToScenario() {
        SceneManager.LoadScene("GameScene");
    }

    private void setToStory() {
        index++;
        SceneManager.LoadScene("StoryScene");
    }
}
