using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollVisualBar : MonoBehaviour
{
    public Image superLowBar;
    public Image lowBar;
    public Image successBar;
    public Image highBar;
    public float duration = 0.5f;

    private float timer;

    private float superLowFillTarget;
    private float lowFillTarget;
    private float successFillTarget;
    private float highFillTarget;

    private float superLowFillCurrent;
    private float lowFillCurrent;
    private float successFillCurrent;
    private float highFillCurrent;

    public void SetValue(int low, int minSuccess, int maxSuccess, int high, int min, int max)
    {
        superLowBar.fillAmount = GetFillAmount(low, min, max);
        lowBar.fillAmount = GetFillAmount(minSuccess, min, max);
        successBar.fillAmount = GetFillAmount(maxSuccess, min, max);
        highBar.fillAmount = GetFillAmount(high, min, max);
    }

    public void SetTargetValue(int low, int minSuccess, int maxSuccess, int high, int min, int max)
    {
        timer = duration;

        superLowFillTarget = GetFillAmount(low, min, max);
        lowFillTarget = GetFillAmount(minSuccess, min, max);
        successFillTarget = GetFillAmount(maxSuccess, min, max);
        highFillTarget = GetFillAmount(high, min, max);

        superLowFillCurrent = superLowBar.fillAmount;
        lowFillCurrent = lowBar.fillAmount;
        successFillCurrent = successBar.fillAmount;
        highFillCurrent = highBar.fillAmount;
    }

    private float GetFillAmount(int value, int min, int max)
    {
        return Mathf.Max(0f, value - min) / (max - min);
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            float ratio = timer / duration;

            superLowBar.fillAmount = Mathf.Lerp(superLowFillTarget, superLowFillCurrent, ratio);
            lowBar.fillAmount = Mathf.Lerp(lowFillTarget, lowFillCurrent, ratio);
            successBar.fillAmount = Mathf.Lerp(successFillTarget, successFillCurrent, ratio);
            highBar.fillAmount = Mathf.Lerp(highFillTarget, highFillCurrent, ratio);
        }
    }
}
