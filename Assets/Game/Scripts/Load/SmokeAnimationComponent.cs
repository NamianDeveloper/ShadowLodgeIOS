using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SmokeAnimationComponent : MonoBehaviour
{
    [SerializeField] private GameObject loadParent;

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite newBackgroundSprite;
    public void HideLoadParent()
    { 
        loadParent.SetActive(false);
        backgroundImage.sprite = newBackgroundSprite;
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
