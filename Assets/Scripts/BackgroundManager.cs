using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private static BackgroundManager singleton;

    public enum BackgroundType
    {
        Scene1,
        Scene2,
        Scene3,
        Random
    }

    public GameObject bgScene1;
    public GameObject bgScene2;
    public GameObject bgScene3;
    public List<GameObject> bgRandom;

    public class BackgroundDesc
    {
        public BackgroundType bgType;
        public List<GameObject> bgGameObjects;

        public BackgroundDesc(BackgroundType bgType, GameObject gameObject)
        {
            this.bgType = bgType;
            this.bgGameObjects = new List<GameObject>();
            this.bgGameObjects.Add(gameObject);
        }

        public BackgroundDesc(BackgroundType bgType, List<GameObject> gameObjects)
        {
            this.bgType = bgType;
            this.bgGameObjects = gameObjects;
        }
    }

    public List<BackgroundDesc> bgDescriptions;

    void Start()
    {
        bgDescriptions.Add(new BackgroundDesc(BackgroundType.Scene1, bgScene1));
        bgDescriptions.Add(new BackgroundDesc(BackgroundType.Scene2, bgScene2));
        bgDescriptions.Add(new BackgroundDesc(BackgroundType.Scene3, bgScene3));
        bgDescriptions.Add(new BackgroundDesc(BackgroundType.Random, bgRandom));
    }

    void Awake()
    {
        if (BackgroundManager.singleton)
        {
            Debug.LogError("Duplicate BackgroundManager.");
            return;
        }

        BackgroundManager.singleton = this;
    }

    static BackgroundManager getSingleton()
    {
        return BackgroundManager.singleton;
    }

    void SetBackground(BackgroundType type)
    {
        for (int i = 0; i < bgDescriptions.Count; i++)
        {
            for (int j = 0; j < bgDescriptions[i].bgGameObjects.Count; j++)
            {
                bgDescriptions[i].bgGameObjects[j].SetActive(false);
            }
        }

        for (int i = 0; i < bgDescriptions.Count; i++)
        {
            if (bgDescriptions[i].bgType == type)
            {
                for (int j = 0; j < bgDescriptions[i].bgGameObjects.Count; j++)
                {
                    bgDescriptions[i].bgGameObjects[j].SetActive(true);
                }
                return;
            }
        }
    }
}
