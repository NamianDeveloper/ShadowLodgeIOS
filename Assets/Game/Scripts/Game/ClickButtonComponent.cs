using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonComponent : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject textUpgradePrefab;
    [SerializeField] private Transform textParent;

    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private ProgressbarComponent progressBarComponent;

    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite[] buttonSprite;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        buttonImage.sprite = buttonSprite[GameManager.Instance.SelectElementID];
    }
    public void ClickButton()
    {
        animator.Play("Click");

        if (UpgradeManager.Instance.moneyClickLeft > 0)
        {
            moneyManager.CurrentMoney += 10;
            Instantiate(textUpgradePrefab, textParent.transform.position + new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), textParent.transform.rotation, textParent);
        }
        else
        {
            moneyManager.CurrentMoney += 5;
            Instantiate(textPrefab, textParent.transform.position + new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), textParent.transform.rotation, textParent);
        }

        progressBarComponent.ClickEvent();

        UpgradeManager.Instance.ClickEvent();
    }

    public IEnumerator Autoclicker()
    {
        while (UpgradeManager.Instance.autoclickClickLeft > 0)
        {
            ClickButton();
            yield return new WaitForSeconds(0.3f); // продолжить примерно через 100ms
        }
        StopCoroutine(Autoclicker());
    }

}
