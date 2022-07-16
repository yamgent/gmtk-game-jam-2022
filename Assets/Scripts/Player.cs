using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TMP_Text healthNumberText;
    public TMP_Text diceNumberText;
    public TMP_Text goldNumberText;

    // Constants set in Unity scene editor.
    public int initialHealth;
    public int initialDice;
    public int initialGold;
    
    private int health;
    private int dice;
    private int gold;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void AddHealth(int amount)
    {
        health = Mathf.Max(health + amount, 0);
        if (health == 0)
        {
            //scenarioManager#loseReasonZeroHealth
        }
        UpdateResourcesUI();
    }

    public void AddDice(int amount)
    {
        dice += amount;
        if (dice < 0)
        {
            dice = 0;
            //scenarioManager#loseReasonNegativeDice
        }
        UpdateResourcesUI();
    }

    public void AddGold(int amount)
    {
        gold = Mathf.Max(gold + amount, 0);
        UpdateResourcesUI();
    }

    public void Reset()
    {
        health = initialHealth;
        dice = initialDice;
        gold = initialGold;
        UpdateResourcesUI();
    }

    private void UpdateResourcesUI()
    {
        healthNumberText.text = health.ToString();
        diceNumberText.text = dice.ToString();
        goldNumberText.text = gold.ToString();
    }
}
