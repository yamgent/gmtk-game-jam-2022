using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollVisualBlock : MonoBehaviour
{
    public TMP_Text blockText;

    public void SetValue(int value)
    {
        blockText.text = "" + value;
    }
}
