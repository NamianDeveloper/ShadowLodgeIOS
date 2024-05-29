using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonComponent : MonoBehaviour
{
    [SerializeField] private ShopUiComponent shopUiComponent;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Click()
    {
        animator.Play("Click");
    }
    public void LoadGameScene()
    {
        GameManager.Instance.SelectElementID = shopUiComponent.CurrentSelectElement;
        SceneManager.LoadScene("GameScene");
    }
}
