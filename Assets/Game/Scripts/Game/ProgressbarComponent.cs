using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressbarComponent : MonoBehaviour
{
    [SerializeField] private int clickToUpgrade;
    [SerializeField] private Image progressbarValueImage;
    [SerializeField] private TextMeshProUGUI progressbarValueText;

    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject textUpgradePrefab;
    [SerializeField] private Transform textParent;

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite[] backgroundSprite;


    private int currentLevel;
    public int CurrentValue
    {
        get => currentValue;
        set
        {
            currentValue = value;
            progressbarValueImage.fillAmount = (float)currentValue / 100;
            progressbarValueText.text = currentValue.ToString() + "%";

            Debug.Log((float)currentValue / 100);
        }
    }
    private int currentValue;

    private int currentClickCount;

    private void Start()
    {
        CurrentValue = PlayerPrefs.GetInt("CURRENT_PROGRESSBAR", 0);
        currentLevel = PlayerPrefs.GetInt("CURRENT_LEVEL", 0);

        backgroundImage.sprite = backgroundSprite[currentLevel];
    }

    public void ClickEvent()
    {
        currentClickCount++;

        if (currentClickCount >= clickToUpgrade)
        {
            if (UpgradeManager.Instance.percentClickLeft > 0)
            {
                CurrentValue += 2;
                Instantiate(textUpgradePrefab, textParent.transform.position + new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), textParent.transform.rotation, textParent);
            }
            else
            {
                CurrentValue++;
                Instantiate(textPrefab, textParent.transform.position + new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), textParent.transform.rotation, textParent);
            }

            currentClickCount = 0;

            if (currentValue >= 100)
            {
                CurrentValue = 0;

                if (currentLevel < backgroundSprite.Length - 1)
                    currentLevel++;

                backgroundImage.sprite = backgroundSprite[currentLevel];
            }
        }
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("CURRENT_PROGRESSBAR", currentValue);
        PlayerPrefs.SetInt("CURRENT_LEVEL", currentLevel);
    }
}
