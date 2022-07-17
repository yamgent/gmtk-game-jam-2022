using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryImageArea : MonoBehaviour
{
    public Image[] images;

    private List<int> imageList;
    private int index;

    void Start()
    {
        Hide();
    }
    
    private void Hide()
    {
        for (int i = 0; i < images.Length; ++i)
        {
            images[i].enabled = false;
        }
    }

    public void Show(int index)
    {
        int imageIndex = -1;
        if (imageList != null) {
            imageIndex = imageList[index];
        }
        if (imageIndex == -1) return;
        
        Hide();
        images[imageIndex].enabled = true;
        StartCoroutine(FadeIn(images[imageIndex]));
    }

    IEnumerator FadeIn(Image image)
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }

    }

    public void SetImageList(List<int> imageList) {
        this.imageList = imageList;
    }
}
