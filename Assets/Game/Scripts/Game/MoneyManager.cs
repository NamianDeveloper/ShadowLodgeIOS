using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public int CurrentMoney
    {
        get => currentMoney;
        set
        {
            currentMoney = value;
            moneyText.text = currentMoney.ToString();
        }
    }

    private int currentMoney;

    private void Start()
    {
        CurrentMoney = PlayerPrefs.GetInt("CURRENT_MONEY", 0);
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("CURRENT_MONEY", currentMoney);
    }
}
