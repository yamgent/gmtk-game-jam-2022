using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollVisualBlock : MonoBehaviour
{
    public TMP_Text blockText;

    private RectTransform rectTransform;
    
    void Awake()
    {
        this.rectTransform = GetComponent<RectTransform>();
    }

    public void SetValue(int value, float max, float maxPosition)
    {
        float ratio = value / max;
        float posX = ratio * maxPosition;

        rectTransform.anchoredPosition = new Vector2(posX, 0);
        blockText.text = "" + value;
    }
}
