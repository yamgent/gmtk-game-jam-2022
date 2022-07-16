using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private static GameEvents singleton;
    private static void SetSingleton(GameEvents instance)
    {
        if (singleton != null)
        {
            Debug.LogError("GameEvents#SetSingleton called more than once.");
            return;
        }
        singleton = instance;
    }
    public static GameEvents GetSingleton()
    {
        return singleton;
    }
    
    void Awake()
    {
        SetSingleton(this);
    }

    public event Action onGameOver;
    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }
}
