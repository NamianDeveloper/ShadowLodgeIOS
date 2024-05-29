using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHomeButton : MonoBehaviour
{
    [SerializeField] private Animator backgroundAnimator;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Click()
    {
        animator.Play("Click");
    }

    public void BackAnimation()
    {
        backgroundAnimator.Play("Hide");
    }
}
