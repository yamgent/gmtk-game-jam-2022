using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    // Constants set in Unity scene editor.
    public int initialHealth;
    public int initialDice;
    public int initialGold;
    
    private int health;
    public int Health {
        get { return health; }
        set {
            health = Mathf.Max(value, 0);
            if (health == 0) {
                GameController.Instance.StartLoseScene();
            }
        }
    }

    private int dice;
    public int Dice {
        get { return dice; }
        set {
            dice = value;
            if (dice < 0) {
                dice = 0;
                GameController.Instance.StartLoseScene();
            }
        }
    }

    private int gold;
    public int Gold {
        get { return gold; }
        set { gold = Mathf.Max(value, 0); }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        health = initialHealth;
        dice = initialDice;
        gold = initialGold;
    }
}
