using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesButton : MonoBehaviour
{
    public GameObject howToPlayOverlay;
    
    public void ToggleOverlay()
    {
        howToPlayOverlay.SetActive(!howToPlayOverlay.activeSelf);
    }
}
