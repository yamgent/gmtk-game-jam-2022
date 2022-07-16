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
    public RectTransform overlayBar;

    private float maxRoll;

    public void SetValue(int low, int minSuccess, int maxSuccess, int high, float maxRoll)
    {
        this.maxRoll = maxRoll;

        superLowBar.fillAmount = low / maxRoll;
        lowBar.fillAmount = minSuccess / maxRoll;
        successBar.fillAmount = maxSuccess / maxRoll;
        highBar.fillAmount = high / maxRoll;
    }

    public void SetOverlayBar(int numDice, float maxRoll, float maxPosition)
    {
        int min = numDice;
        int max = 6 * numDice;

        float startOffset = (min / maxRoll) * maxPosition;
        float endOffset = Mathf.Min(0, ((max - maxRoll) / maxRoll) * maxPosition);

        overlayBar.offsetMin = new Vector2(startOffset, overlayBar.offsetMin.y);
        overlayBar.offsetMax = new Vector2(endOffset, overlayBar.offsetMax.y);
    }
}
