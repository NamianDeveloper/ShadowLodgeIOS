using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUiComponent : MonoBehaviour
{
    public int CurrentSelectElement => installedElement;

    [SerializeField] private MoneyMenuManager moneyMenuManager;

    [SerializeField] private GameObject mainUiPanel;

    [SerializeField] private GameObject[] selectOuylineObjects;

    [SerializeField] private Image buttonImage;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Sprite[] buutinSprite;

    [SerializeField] private int[] costs;

    private int installedElement;
    private int currentSelectElement;

    private void Start()
    {
        PlayerPrefs.SetInt($"ITEM_STATUS_0", 1);

        SelectElement(0);
    }
    public void ChangeWindow()
    {
        switch (MenuUiManager.Instance.CurrentWindowID)
        {
            case 0:
                mainUiPanel.SetActive(true);
                break;
        }

        gameObject.SetActive(false);
    }

    public void SelectElement(int id)
    {
        selectOuylineObjects[currentSelectElement].gameObject.SetActive(false);

        currentSelectElement = id;

        selectOuylineObjects[currentSelectElement].gameObject.SetActive(true);

        if (installedElement == currentSelectElement)
        {
            buttonImage.sprite = buutinSprite[0];
            costText.gameObject.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.HasKey($"ITEM_STATUS_{id}"))
            { 
                buttonImage.sprite = buutinSprite[1];
                costText.gameObject.SetActive(false);
            }
            else
            {
                buttonImage.sprite = buutinSprite[2];
                costText.gameObject.SetActive(true);
                costText.text = costs[currentSelectElement].ToString();

                if (moneyMenuManager.CurrentMoney >= costs[currentSelectElement])
                {
                    costText.color = new Color(0, 0, 0, 1);
                }
                else
                {
                    costText.color = new Color(0.35f, 0.35f, 0.35f, 1);
                }
            }
        }
    }

    public void InstallElement()
    {
        if (installedElement == currentSelectElement)
        {
            return;
        }
        else
        {
            if (PlayerPrefs.HasKey($"ITEM_STATUS_{currentSelectElement}"))
            {
                buttonImage.sprite = buutinSprite[0];
                installedElement = currentSelectElement;
            }
            else
            {
                if (moneyMenuManager.CurrentMoney >= costs[currentSelectElement])
                {
                    buttonImage.sprite = buutinSprite[1];
                    PlayerPrefs.SetInt($"ITEM_STATUS_{currentSelectElement}", 1);
                    moneyMenuManager.CurrentMoney -= costs[currentSelectElement];

                    costText.gameObject.SetActive(false);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
