using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private float loadTime = 5;
    [SerializeField] private GameObject smokeObject;
    private void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(loadTime);
        smokeObject.SetActive(true);
        Debug.Log("Was load");
    }
}
