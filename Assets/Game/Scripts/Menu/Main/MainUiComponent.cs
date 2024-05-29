using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUiComponent : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject shopPanel;

    public void ChangeWindow()
    {
        switch (MenuUiManager.Instance.CurrentWindowID)
        {
            case 1:
                settingPanel.SetActive(true);
                break;
            case 2:
                shopPanel.SetActive(true);
                break;
        }

        gameObject.SetActive(false);
    }
}
