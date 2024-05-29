using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonComponent : MonoBehaviour
{
    [SerializeField] private Animator settingPanelAnimator;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Click()
    {
        animator.Play("Click");
    }
    public void OpenSetting()
    {
        MenuUiManager.Instance.CurrentWindowID = 2;
        settingPanelAnimator.Play("Hide");
    }
}
