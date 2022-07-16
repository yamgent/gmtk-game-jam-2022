using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public DialogueAnimation dialogueAnimation;

    private BaseStory currentStory;

    // Start is called before the first frame update
    void Start()
    {
        LoadStory(GameController.Instance.storyList[GameController.Instance.index]);
    }

    public void LoadStory(BaseStory story) 
    {
        currentStory = story;
        dialogueAnimation.SetDialogue(story.GetStoryTextList());
    }

}
