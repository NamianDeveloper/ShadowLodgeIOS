using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUiManager : MonoBehaviour
{
    public static MenuUiManager Instance;

    public int CurrentWindowID = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
