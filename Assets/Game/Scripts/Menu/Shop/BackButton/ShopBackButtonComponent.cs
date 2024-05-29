using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBackButtonComponent : MonoBehaviour
{
    [SerializeField] private Animator MainMenuPanelAnimator;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Click()
    {
        animator.Play("Click");
    }
    public void OpenMainMenu()
    {
        MenuUiManager.Instance.CurrentWindowID = 0;
        MainMenuPanelAnimator.Play("Hide");
    }
}
