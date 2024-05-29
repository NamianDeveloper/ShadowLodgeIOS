using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUiComponent : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;

    public void ChangeWindow()
    {
        switch (MenuUiManager.Instance.CurrentWindowID)
        {
            case 0:
                mainPanel.SetActive(true);
                break;
        }

        gameObject.SetActive(false);
    }
}
