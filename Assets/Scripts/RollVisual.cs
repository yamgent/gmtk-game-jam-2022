using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollVisual : MonoBehaviour
{
    public RollVisualBar bar;
    public RollVisualBlock lowNumberBlock;
    public RollVisualBlock minNumberBlock;
    public RollVisualBlock maxNumberBlock;
    public RollVisualBlock highNumberBlock;

    private float maxValue;
    private float maxPosition;
    
    void Awake()
    {
        this.maxPosition = GetComponent<RectTransform>().rect.width;
    }

    public void InitializeRollVisual(BaseScenario scenario)
    {
        this.maxValue = Mathf.Ceil((scenario.highRoll * 1.0f) / 6) * 6;
        
        bar.SetValue(scenario.lowRoll, scenario.minSuccess, scenario.maxSuccess, scenario.highRoll, maxValue);
        bar.SetOverlayBar(1, maxValue, maxPosition);
        lowNumberBlock.SetValue(scenario.lowRoll, maxValue, maxPosition);
        minNumberBlock.SetValue(scenario.minSuccess, maxValue, maxPosition);
        maxNumberBlock.SetValue(scenario.maxSuccess, maxValue, maxPosition);
        highNumberBlock.SetValue(scenario.highRoll, maxValue, maxPosition);
    }

    public void NumDiceChanged(int numDice)
    {
        bar.SetOverlayBar(numDice, maxValue, maxPosition);
    }
}
