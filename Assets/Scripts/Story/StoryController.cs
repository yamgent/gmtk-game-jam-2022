using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public DialogueAnimation dialogueAnimation;
    public StoryImageArea storyImageArea;

    private BaseStory currentStory;
    private List<BaseStory> randomStoryList = new List<BaseStory> {
        new RandomStory1(),
        new RandomStory2(),
        new RandomStory3(),
        new RandomStory4(),
        new RandomStory5(),
        new RandomStory6(),
        new RandomStory7(),
        new RandomStory8(),
    };

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.Instance.isStoryScenario)
        {
            LoadStory(GameController.Instance.storyList[GameController.Instance.index]);
        }
        else
        {
            LoadStory(randomStoryList[Random.Range(0, randomStoryList.Count)]);
        }
    }

    public void LoadStory(BaseStory story) 
    {
        currentStory = story;
        storyImageArea.SetImageList(story.GetStoryImageList());
        dialogueAnimation.SetDialogue(story.GetStoryTextList());
    }
}
