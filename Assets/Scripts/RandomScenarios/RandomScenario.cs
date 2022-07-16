using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RandomScenario : MonoBehaviour
{
    public abstract string GetTitle();

    public abstract void PerformResult(int rolledNumber);

    protected string resultText = "No result yet.";
    public string GetResultText()
    {
        return resultText;
    }
}
