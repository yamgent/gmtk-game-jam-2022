using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollVisual : MonoBehaviour
{
    public RollVisualBar bar;
    public RollVisualBlock minRollBlock;
    public RollVisualBlock maxRollBlock;

    private float maxValue;
    private float maxPosition;
    private BaseScenario scenario;
    
    void Awake()
    {
        this.maxPosition = GetComponent<RectTransform>().rect.width;
    }

    public void InitializeRollVisual(BaseScenario scenario)
    {
        this.maxValue = Mathf.Ceil((scenario.highRoll * 1.0f) / 6) * 6;
        this.scenario = scenario;

        bar.SetValue(scenario.lowRoll, scenario.minSuccess, scenario.maxSuccess, scenario.highRoll, 1, 6);
    }

    public void UpdateRollVisual(int numDice)
    {
        int min = numDice;
        int max = numDice * 6;

        minRollBlock.SetValue(min);
        maxRollBlock.SetValue(max);

        bar.SetTargetValue(scenario.lowRoll, scenario.minSuccess, scenario.maxSuccess, scenario.highRoll, min, max);
    }
}
