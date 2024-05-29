using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public int moneyClickLeft;
    public int autoclickClickLeft;
    public int percentClickLeft;

    [SerializeField] private GameObject[] plusObjects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClickEvent()
    {
        if (moneyClickLeft > 0)
        {
            moneyClickLeft--;
            if (moneyClickLeft <= 0)
                plusObjects[0].SetActive(true);
        }

        if (autoclickClickLeft > 0)
        {
            autoclickClickLeft--;
            if (autoclickClickLeft <= 0)
                plusObjects[1].SetActive(true);
        }

        if (percentClickLeft > 0)
        {
            percentClickLeft--;
            if (percentClickLeft <= 0)
                plusObjects[2].SetActive(true);
        }
    }
}
