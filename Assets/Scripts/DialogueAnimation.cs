using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueAnimation : MonoBehaviour
{
    public delegate void AnimatedTextCompleted();
    public event AnimatedTextCompleted OnAnimatedTextCompleted;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI displayedTextMesh;
    [SerializeField] private float delayBetweenWord = 0.5f;    

    public DialogueNext dialogueNext;
    public StoryImageArea storyImageArea;  

    private string textToAnimate;
    private string currentText;        

    private string[] splitMessage;
    private int indexWord = 0;
    private string previousWord;

    private List<string> dialogueList;
    private int currentTextIndex;
    private bool dialgueAnimationCompleted;

    Coroutine coroutine;

    public void AnimateText(float startDelay, string text)
    {
        textToAnimate = text;

        displayedTextMesh.text = "";
        indexWord = 0;

        splitMessage = text.Split(' ');

        coroutine = StartCoroutine(StartAnimation(startDelay));
    }

    public void SetDialogue(List<string> dialogueList) {
        this.dialogueList = dialogueList;
        currentTextIndex = 0;
        dialgueAnimationCompleted = true;
        Next();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogueList != null)
        {
            Next();
        }
    }

    private void Next() 
    {
        dialogueNext.Hide();

        if (dialgueAnimationCompleted) 
        {
            if (currentTextIndex < dialogueList.Count) 
            {
                dialgueAnimationCompleted = false;
                AnimateText(0.2f, dialogueList[currentTextIndex]);
                if (storyImageArea != null)
                {
                    storyImageArea.Show(currentTextIndex);
                }
                currentTextIndex++;
            }
            else
            {
                GameController.Instance.SwitchStoryAndScenario();
            }
        }
        else 
        {
            Skip();
        }
        
    }

    private IEnumerator StartAnimation(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);

        currentText = "";

        // Store first word
        previousWord = splitMessage[0]; // Save previous word with no style            
        displayedTextMesh.text = splitMessage[indexWord];

        indexWord = 1;
        while (indexWord < splitMessage.Length)
        {
            yield return new WaitForSeconds(delayBetweenWord);
            // Add to current text previous word (no style) + next one with style
            currentText += previousWord + " ";
            displayedTextMesh.text = currentText + "" + splitMessage[indexWord];

            // Save previous word with no style and add 1
            previousWord = splitMessage[indexWord];
            indexWord += 1;

        }

        yield return new WaitForSeconds(delayBetweenWord);
        displayedTextMesh.text = textToAnimate;

        // Event finished
        dialgueAnimationCompleted = true;
        if (OnAnimatedTextCompleted != null)
        {
            OnAnimatedTextCompleted();
        }
    }

    public void Skip() 
    {
        StopCoroutine(coroutine);
        displayedTextMesh.text = textToAnimate;
        dialgueAnimationCompleted = true;
        if (OnAnimatedTextCompleted != null)
        {
            OnAnimatedTextCompleted();
        }
    }
}
