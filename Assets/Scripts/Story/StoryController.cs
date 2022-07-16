using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public GameObject dialoguePrefab;

    private DialogueAnimation dialogueAnimation;
    private int currentTextIndex;
    private bool dialgueAnimationCompleted;

    private BaseStory currentStory;

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.Instance.isStoryScene) {
            LoadStory(GameController.Instance.storyList[GameController.Instance.index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
    }

    public void LoadStory(BaseStory story) 
    {
        currentStory = story;
        dialogueAnimation = dialoguePrefab.GetComponent<DialogueAnimation>();
        dialogueAnimation.OnAnimatedTextCompleted += OnAnimatedTextCompleted;
        currentTextIndex = 0;
        dialgueAnimationCompleted = true;
        Next();
    }


    public void Next() 
    {
        if (dialgueAnimationCompleted) 
        {
            if (currentTextIndex < currentStory.GetStoryTextList().Count) 
            {
                dialgueAnimationCompleted = false;
                dialogueAnimation.AnimateText(0.2f, currentStory.GetStoryTextList()[currentTextIndex]);
                currentTextIndex++;
            }
            else
            {
                GameController.Instance.setToScenario();
                SceneManager.LoadScene("GameScene");
            }
        }
        else 
        {
            dialogueAnimation.Skip();
        }
        
    }

    public void OnAnimatedTextCompleted() {
        dialgueAnimationCompleted = true;
    }
}
