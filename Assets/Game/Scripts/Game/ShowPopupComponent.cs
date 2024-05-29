using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupComponent : MonoBehaviour
{
    [SerializeField] private GameObject plusGameObject;

    [SerializeField] private int popupID;

    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private ClickButtonComponent clickButtonComponent;

    [SerializeField] private GameObject popupParent;
    [SerializeField] private GameObject popupObject;

    private void Start()
    {
        popupObject.SetActive(false);
        popupParent.SetActive(false);
    }

    public void ShowPopup(bool status)
    {
        switch (popupID)
        {
            case 0:
                if (UpgradeManager.Instance.moneyClickLeft > 0)
                    return;
                break;
            case 1:
                if (UpgradeManager.Instance.autoclickClickLeft > 0)
                    return;
                break;
            case 2:
                if (UpgradeManager.Instance.percentClickLeft > 0)
                    return;
                break;
        }

        popupParent.SetActive(status);
        popupObject.SetActive(status);

        if (status)
            Time.timeScale = 0.00005f;
        else
            Time.timeScale = 1f;
    }

    public void BuyUpgrade(int upgradeID)
    {
        if (moneyManager.CurrentMoney < 250)
            return;

        moneyManager.CurrentMoney -= 250;
        ShowPopup(false);

        plusGameObject.SetActive(false);

        switch (upgradeID)
        {
            case 0:
                UpgradeManager.Instance.moneyClickLeft = 100;
                break;
            case 1:
                UpgradeManager.Instance.autoclickClickLeft = 100;
                StartCoroutine(clickButtonComponent.Autoclicker());
                break;
            case 2:
                UpgradeManager.Instance.percentClickLeft = 100;
                break;
        }
    }
}
