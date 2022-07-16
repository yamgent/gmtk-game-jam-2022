using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Constants set in Unity scene editor.
    public int initialHealth;
    public int initialMoney;
    
    private int maxHealth;
    private int health;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents gameEventsSingleton = GameEvents.GetSingleton();
        gameEventsSingleton.onGameOver += HandleGameOver;

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleGameOver()
    {
        Reset();
    }

    void Reset()
    {
        maxHealth = initialHealth;
        health = initialHealth;
        money = initialMoney;
    }

    void AddHealth(int amount)
    {
        health = Mathf.Max(Mathf.Min(health + amount, 0), maxHealth);
        if (health == 0)
        {
            GameEvents.GetSingleton().GameOver();
        }
    }

    void AddMoney(int amount)
    {
        money = Mathf.Min(money + amount, 0);
    }
}
