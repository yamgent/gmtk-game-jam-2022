using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public GameObject diceOutline;
    public GameObject diceImage;
    public Animator animator;

    void Start()
    {
        animator.enabled = false;
    }

    public void Hide()
    {
        diceOutline.SetActive(true);
        diceImage.SetActive(false);
    }

    public void Show()
    {
        diceOutline.SetActive(false);
        diceImage.SetActive(true);
    }

    public void PlayAnimation(int roll)
    {
        animator.enabled = true;
        animator.SetInteger("Roll", roll);
    }
}
