using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueAnimation : MonoBehaviour
{
    public delegate void AnimatedTextCompleted();
    public static event AnimatedTextCompleted OnAnimatedTextCompleted;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI displayedTextMesh;
    [SerializeField] private float delayBetweenWord = 0.1f;            

    private string textToAnimate;
    private string currentText;        

    private string[] splitMessage;
    private int indexWord = 0;
    private string previousWord;

    public void AnimateText(float startDelay, string text)
    {
        textToAnimate = text;

        displayedTextMesh.text = "";

        splitMessage = text.Split(' ');

        StartCoroutine(StartAnimation(startDelay));
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
        if (OnAnimatedTextCompleted != null)
        {
            OnAnimatedTextCompleted();
        }
    }
}
