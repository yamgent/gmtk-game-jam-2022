using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour
{
    private float swayAmount = 40.0f;
    private float swayDuration = 5.0f;
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float yDelta = Mathf.Sin((Time.time / swayDuration) * (2.0f * Mathf.PI)) * swayAmount;
        Vector3 pos = transform.position;
        pos.y = startY + yDelta;
        transform.position = pos;
    }
}
