using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMusicController : MonoBehaviour
{
    public AudioSource ingameMusic;

    public static IngameMusicController instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void PlayIfNotStarted()
    {
        if (!ingameMusic.isPlaying)
        {
            ingameMusic.Play();
        }
    }

    void StopMusic()
    {
        ingameMusic.Stop();
    }
}
