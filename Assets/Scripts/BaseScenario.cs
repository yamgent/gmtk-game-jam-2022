using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScenario : MonoBehaviour
{
    public abstract string GetTitle();

    public abstract List<string> GetPreRollTextList();

    public abstract void PerformRollResult(int rolledNumber);

    public abstract List<string> GetPostRollTextList(int rolledNumber);
}
