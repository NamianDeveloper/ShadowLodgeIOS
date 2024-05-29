using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButtonComponent : MonoBehaviour
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
        MenuUiManager.Instance.CurrentWindowID = 1;
        settingPanelAnimator.Play("Hide");
    }
}
