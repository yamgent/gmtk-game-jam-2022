using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopIngameMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IngameMusicController musicController = IngameMusicController.instance;

        if (musicController != null)
        {
            musicController.StopMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
