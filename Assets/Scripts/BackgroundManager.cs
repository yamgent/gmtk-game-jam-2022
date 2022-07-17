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

    public List<BackgroundDesc> bgDescriptions = new List<BackgroundDesc>();

    void Start()
    {
        bgDescriptions.Add(new BackgroundDesc(BackgroundType.Scene1, bgScene1));
        bgDescriptions.Add(new BackgroundDesc(BackgroundType.Scene2, bgScene2));
        bgDescriptions.Add(new BackgroundDesc(BackgroundType.Scene3, bgScene3));
        bgDescriptions.Add(new BackgroundDesc(BackgroundType.Random, bgRandom));
    }

    void Awake()
    {
        if (BackgroundManager.singleton != null)
        {
            Debug.LogError("Duplicate BackgroundManager.");
            return;
        }

        BackgroundManager.singleton = this;
    }

    public static BackgroundManager GetSingleton()
    {
        return BackgroundManager.singleton;
    }

    public void SetBackground(BackgroundType type)
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
                int randomBgIndex = 0;

                if (bgDescriptions[i].bgGameObjects.Count > 1)
                {
                    randomBgIndex = Random.Range(0, bgDescriptions[i].bgGameObjects.Count);
                }

                bgDescriptions[i].bgGameObjects[randomBgIndex].SetActive(true);
                return;
            }
        }
    }

    public void SetStoryBackground(int storyIndex)
    {
        switch (storyIndex)
        {
            case 0:
                SetBackground(BackgroundType.Scene1);
                break;
            case 1:
                SetBackground(BackgroundType.Scene2);
                break;
            case 2:
                SetBackground(BackgroundType.Scene3);
                break;
            default:
                Debug.LogError("Invalid storyIndex.");
                break;
        }
    }

    public void SetRandomBackground()
    {
        SetBackground(BackgroundType.Random);
    }
}
