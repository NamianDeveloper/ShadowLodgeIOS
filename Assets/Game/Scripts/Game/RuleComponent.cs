using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("IS_SHOW_RULE"))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Close()
    {
        PlayerPrefs.SetInt("IS_SHOW_RULE", 1);
        gameObject.SetActive(false);
    }
}
