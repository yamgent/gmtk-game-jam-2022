using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateDestroyer : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameController.Instance);
        Destroy(Player.Instance);
    }
}
