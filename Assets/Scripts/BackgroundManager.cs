using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject bgScene1;
    public GameObject bgScene2;
    public GameObject bgScene3;
    public List<GameObject> bgRandom;

    private void HideBg()
    {
        bgScene1.SetActive(false);
        bgScene2.SetActive(false);
        bgScene3.SetActive(false);
        for (int i = 0; i < bgRandom.Count; ++i)
        {
            bgRandom[i].SetActive(false);
        }
    }

    public void SetStoryBackground(int storyIndex)
    {
        HideBg();
        switch (storyIndex)
        {
            case 0:
                bgScene1.SetActive(true);
                break;
            case 1:
                bgScene2.SetActive(true);
                break;
            case 2:
                bgScene3.SetActive(true);
                break;
            default:
                Debug.LogError("Invalid storyIndex.");
                break;
        }
    }

    public void SetRandomBackground()
    {
        HideBg();

        bgRandom[Random.Range(0, bgRandom.Count)].SetActive(true);
    }
}
