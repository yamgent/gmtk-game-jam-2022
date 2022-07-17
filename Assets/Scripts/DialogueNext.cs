using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueNext : MonoBehaviour
{
    public TMP_Text nextText;
    public float amplitude = 0.5f;
    public float speed = 1.5f;
    public float duration = 3.0f;

    private float timer;

    void Start()
    {
        Hide();
    }

    void Update()
    {
        if (timer < 0) {
            nextText.enabled = true;
        } else {
            timer -= Time.deltaTime;
        }

        Color c = nextText.color;
        c.a = 1 - Mathf.Abs(Mathf.Sin(speed * Time.time) * amplitude);
        nextText.color = c;
    }

    public void Hide()
    {
        nextText.enabled = false;
        timer = duration;
    }
}
